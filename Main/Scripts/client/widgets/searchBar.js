mslc.define('client/widgets/searchBar',
    [
        'lib/jQuery'
        , 'lib/ko'
        , 'client/util'
        , 'client/config'
        , 'client/text'
        , 'client/services/remote'
        , 'client/models/enums/keyCode'
        , 'client/controls/select'
        , 'client/controls/autocomplete'
        , 'client/analytics/google'
    ],
    function($, ko, util, config, text, remote, KeyCode, Select, Autocomplete, ga) {
        'use strict';

        function SearchBar(data, $form) {
            //#region PrivateF

            var self = this;

            var badSearchValue = ko.observable();
            var isUserInputAction = true;
            var autocomplete = {
                ajax: null,
                timer: null,
                delay: null,
                minLength: 2
            };

            //#endregion

            //#region Public

            function autocompleteLocation() {
                var result = null;

                var isVisible = !util.isNullOrEmpty(self.lookupLocation())
                    && self.autocomplete.length()
                    && self.autocomplete.index() === -1
                    && self.isHelpAreaVisible();

                if (isVisible) {
                    var lookup = self.lookupLocation();
                    var first = self.autocomplete.list()[0].lookupLocation;

                    var isVisibleFirst = !util.isNullOrEmpty(first)
                        && first.length >= lookup.length
                        && util.startsWith(first, lookup, true);

                    result = isVisibleFirst
                        ? lookup + first.substring(lookup.length, first.length)
                        : lookup;
                }

                return result;
            }

            function isAutocompleteVisible() {
                var result = self.autocomplete.length();
                return (result);
            }

            function isTemplatesVisible() {
                var result = !self.isAutocompleteVisible();
                return (result);
            }

            function currentTemplates() {
                var result = self.templates[self.searchTypes.selected.value()];
                return result;
            }

            function onSearchTypeSelect() {
                self.getAutocomplete();
            }

            function onLookupLocationChange() {
                if (!isUserInputAction) {
                    isUserInputAction = true;
                    return;
                }

                self.getAutocomplete();
            }

            function onAutocompleteSelect(newValue) {

                if (!util.isNullOrUndef(newValue) && !util.isNullOrEmpty(newValue.lookupLocation)) {
                    isUserInputAction = false;
                    self.lookupLocation(newValue.lookupLocation);
                }
            }

           function onDefaultValueSelect(lookupLocation) {
                if (!util.isNullOrEmpty(lookupLocation)) {
                    isUserInputAction = false;
                    self.lookupLocation(lookupLocation);
                    self.isHelpAreaVisible(false);
                }
            }

            function onKeyDown(model, event) {
                var key = event.keyCode;

                if (event.shiftKey || event.ctrlKey || event.altKey) {
                    return true;
                }

                var lookup = util.safeToLowerCase(self.lookupLocation());
                var autocomplete = util.safeToLowerCase(self.autocompleteLocation());

                if (key === KeyCode.DOWN_ARROW || key === KeyCode.PAGE_DOWN) {
                    self.autocomplete.next();
                } else if (key === KeyCode.UP_ARROW || key === KeyCode.PAGE_UP) {
                    self.autocomplete.prev();
                } else if (key === KeyCode.ENTER) {
                    $form.submit();
                } else if ((key === KeyCode.RIGHT_ARROW || key === KeyCode.END || key === KeyCode.TAB)
                    && !util.isNullOrEmpty(autocomplete) && lookup !== autocomplete) {
                    self.lookupLocation(self.autocompleteLocation());
                } else if (key === KeyCode.ESC) {
                    self.hideHelpArea();
                } else {
                    return true;
                }

                return false;
            }

            function onDoubleClick(model, event) {
                $(event.target).select();
                return false;
            }

            function onAutocompleteClick() {
                self.hideHelpArea();
                self.autocomplete.clear();
            }

            function onTemplateClick(data) {
                self.lookupLocation(data.lookupLocation);
            }

            function onAutocompleteClickWithoutRedirect() {
                self.autocomplete.clear();
                self.isHelpAreaVisible(false);
            }

            function showHelpArea() {
                self.isHelpAreaVisible(true);
            }

            function hideHelpArea() {
                self.isHelpAreaVisible(false);
            }

            function hideMessages() {
                self.messages.isEmptyMessageVisible(false);
                self.messages.isErrorMessageVisible(false);
            }

            function getCriteria() {
                var result = {
                    'lookupLocation.searchType': self.searchTypes.selected.value(),
                    'lookupLocation.lookupLocation': self.lookupLocation()
                };

                return result;
            }

            function getAutocomplete() {
                self.hideMessages();
                clearTimeout(autocomplete.timer);

                if (!util.isNull(autocomplete.ajax)) {
                    autocomplete.ajax.abort();
                }

                if (self.lookupLocation().length >= autocomplete.minLength) {
                    autocomplete.timer = setTimeout(function() {
                        autocomplete.ajax = remote.get.autocomplete(self.getCriteria(), function(list) {
                            self.autocomplete.update(list);
                        });
                    }, autocomplete.delay);
                } else {
                    self.autocomplete.clear();
                }
            }

            function search() {
                self.hideHelpArea();

                self.autocomplete.clear();

                if (!util.isNullOrEmpty(self.lookupLocation())) {

                    /*$('#shcCategories option:selected').each(function () {
                        $(this).prop('selected', false);
                    });
                    $('#shcCategories').multiselect('refresh');*/

                    self.pending(true);
                    if (self.getCriteria()['lookupLocation.searchType'] != 4) {
                        var result = {
                            'lookupLocation.searchType': 3,
                            'lookupLocation.lookupLocation': self.lookupLocation()
                        };
                    } else {
                        var result = {
                            'lookupLocation.searchType': self.searchTypes.selected.value(),
                            'lookupLocation.lookupLocation': self.lookupLocation()
                        };
                    }

                    remote.get.searchFromBar(result, function (response) {
                        if (response.isValid) {
                            var shcCat = $("#shcCategories").val();
                            if (self.getCriteria()['lookupLocation.searchType'] == 4)
                                window.location = response.searchUrl;
                            else window.location = shcCat && shcCat.length ? response.searchUrl + "?shc-categories=" + shcCat.join('-') : response.searchUrl;
                        } else {
                            if (response.variants.length) {
                                self.autocomplete.update(response.variants);
                            } else {
                                ga.trackUnresolvedSearch(self.lookupLocation(), { country: 'USA' });
                            }

                            badSearchValue(self.lookupLocation());
                            self.messages.isErrorMessageVisible(true);
                            self.pending(false);
                            self.showHelpArea();
                        }
                    }).fail(function() {
                        self.pending(false);
                    });
                } else {
                    self.messages.isEmptyMessageVisible(true);
                    self.showHelpArea();
                }

                return false;
            }
            
            //#endregion

            //#region Interface

            this.searchTypes = new Select(data.searchTypeList, data.searchType, { stubText: null });
            this.shCategories = ko.observable(data.shCategories);
            this.selectedCategories = ko.observable();
            this.lookupLocation = ko.observable(data.lookupLocation);
            this.templates = data.templates;
            this.isAutocompleteVisibleFlag = ko.observable(true);
            this.isTemplatesVisibleFlag = ko.observable(true);
            this.autocomplete = new Autocomplete();
            this.pending = ko.observable(false);
            this.messages = {
                errorMessage: ko.computed(function() {
                    var result = util.format(text.message('noResutlsErrorMessage'), badSearchValue());
                    return result;
                }),
                isEmptyMessageVisible: ko.observable(false),
                isErrorMessageVisible: ko.observable(false)
            };
            //NOTE: Notify always because we can hide help area by 'selectManager.js' engine
            this.isHelpAreaVisible = ko.observable(false).extend({ notify: 'always' });

            this.autocompleteLocation = ko.computed(autocompleteLocation);
            this.isAutocompleteVisible = ko.computed(isAutocompleteVisible);
            this.isTemplatesVisible = ko.computed(isTemplatesVisible);
            this.currentTemplates = ko.computed(currentTemplates);

            self.searchTypes.selected.subscribe(onSearchTypeSelect);
            self.lookupLocation.subscribe(onLookupLocationChange);
            self.autocomplete.current.subscribe(onAutocompleteSelect);

            this.onKeyDown = onKeyDown;
            this.onDoubleClick = onDoubleClick;
            this.onAutocompleteClick = onAutocompleteClick;
            this.onTemplateClick = onTemplateClick;
            this.showHelpArea = showHelpArea;
            this.hideHelpArea = hideHelpArea;
            this.hideMessages = hideMessages;
            this.getCriteria = getCriteria;
            this.getAutocomplete = getAutocomplete;
            this.search = search;
            this.onDefaultValueSelect = onDefaultValueSelect;
            this.onAutocompleteClickWithoutRedirect = onAutocompleteClickWithoutRedirect;

            //#endregion

            return this;
        }

        return SearchBar;
    });
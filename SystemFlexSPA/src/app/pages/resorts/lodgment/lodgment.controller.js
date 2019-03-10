(function () {
    'use strict';

    angular
        .module('app.resorts.lodgment')
        .controller('LodgmentController', LodgmentController)

    function LodgmentController($scope, $http, $window, $stateParams, $state, WEBAPI, _, spinnerService) {
        /*viewModels*/
        var vm = this;

        //Data
        vm.dtFrom;
        vm.dtTo;
        vm.standardSelected;
        vm.dataSelected = [];
        vm.standardSelectItems = [];
        vm.lodgmentData;
        $scope.loading = false;

        //Method
        vm.goToRecordStay = goToRecordStay;
        vm.dtPickeropen1 = dtPickeropen1;
        vm.dtPickeropen2 = dtPickeropen2;
        vm.selectionComboBox = selectionComboBox;
       
        function load() {
            if ($stateParams.user) {
                $window.location.reload();
            }
            $http.get(WEBAPI.URL + '/api/PersonsCatalog')
              .success(function (data) {
                  _.each(data, function (element, index) {
                      vm.standardSelectItems[index] = _.extend(element, { label: element.adultsQuantity + ' Adultos/ ' + element.roomQuantity + ' habitacion(es)', value: element.idCatalog });
                  });
                  if (!$scope.$$phase) {
                      $scope.$apply();
                  };
              })

                .error(function (status) {

                });
        }

        //  vm.standardSelectItems = [
        //{ label: 'Opcion 1', value: 1 },
        //{ label: 'Opcion 2', value: 2 },
        //{ label: 'Opcion 3', value: 3 },
        //{ label: 'Opcion 4', value: 4 },
        //  ];

        /**Date picker popup functions**/
        /*
         * *Date picker 1
         */
        function dtPickeropen1() {
            vm.popup1.opened = true;
        };

        vm.popup1 = {
            opened: false
        };


        /*
         * *Date picker 2
         */
        function dtPickeropen2() {
            vm.popup2.opened = true;
        };

        vm.popup2 = {
            opened: false
        };
        /**End section**/


        /**Format date picker (dd/MM/yyyy) **/
        vm.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate', 'dd/MM/yyyy'];
        vm.format = vm.formats[4];

        function selectionComboBox() {

            if (!vm.standardSelected) {
                //nothing
            }
            else {
                vm.dataSelected.length = 0;
                vm.dataSelected.push(vm.standardSelected);
            }

        }

        //function to save data completed of lodgment
        function goToRecordStay() {

            $scope.loading = true;
            /*find the number of days between two Date objects*/
            var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
            var firstDate = new Date(vm.dtFrom);
            var secondDate = new Date(vm.dtTo);
            var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay)));

            vm.lodgmentData = {
                userId: 1,
                catalogId: vm.dataSelected[0].idCatalog, 
                initialDate: vm.dtFrom,
                endDate: vm.dtTo,
                days: diffDays,
                creationDate: new Date()
            }

            $http.post(WEBAPI.URL + '/api/StayDetail', vm.lodgmentData)
                .success(function (data) {
                    //nothing that wait
                    $state.go('resorts.recordstay', null);
                })

                .error(function (status) {

                }).finally(function () {
                    $scope.loading = false;
                });
        }


        load();

    }
})();

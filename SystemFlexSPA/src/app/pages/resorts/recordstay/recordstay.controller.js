(function () {
    'use strict';

    angular
        .module('app.resorts.recordstay')
        .controller('RecordStayController', RecordStayController)


    function RecordStayController($http, $state, $stateParams, $scope, WEBAPI, deleteRecordStayModal, spinnerService) {
        /* viewModels */
        var vm = this;
        //Data
        vm.recordstayList = [];
        $scope.loading = false;

        //Methods
        vm.load = load;
        vm.selectRoom = selectRoom;
        vm.modifyRequest = modifyRequest;
        vm.deleteRequest = deleteRequest;



        function load() {
            $scope.loading = true;
            $http.get(WEBAPI.URL + '/api/VWStayDetail')
            .success(function (data) {
                vm.recordstayList = data;
                if (!$scope.$$phase) {
                    $scope.$digest();
                };
            })
            .error(function (data) {

            }).finally(function () {
                $scope.loading = false;
            });;
        }

        //function select room for go to wizard payment check
        function selectRoom(recordStay) {
            $state.go('resorts.payment_check', { recordStay: recordStay });
        }

        //function modify
        function modifyRequest(recordStay) {
            $state.go('resorts.lodgment', recordStay);
        }

        //function delete
        function deleteRequest(recordstay) {
            deleteRecordStayModal.open({
                locals: {
                    recordstay: recordstay,
                    recordstayList: vm.recordstayList
                }
            });
        }

        load();

    }
})();

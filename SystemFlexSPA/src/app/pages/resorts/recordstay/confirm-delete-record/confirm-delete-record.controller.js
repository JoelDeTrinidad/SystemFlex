(function () {
    'use strict';
    angular
    .module('app.resorts.recordstay')
    .controller('DeleteRecordStayDialogController', DeleteRecordStayDialogController)
    function DeleteRecordStayDialogController(locals, WEBAPI, $http) {
        var vm = this;
        //Data 
        vm.locals = locals;
        //Methods
        vm.deleteRecordStay = deleteRecordStay;

        function deleteRecordStay() {
            $http.delete(WEBAPI.URL + '/api/VWStayDetail', {
                params: {
                    id: vm.locals.recordstay.detailId
                }
            })
            .success(function (data) {
                vm.locals.recordstayList = _.reject(vm.locals.recordstayList, function rejectRecord() { return rejectRecord.id == vm.locals.deleteRecordStay.id });
                console.log(data.data);

            })
            .error(function (data) {

            });
        }

    }
})();
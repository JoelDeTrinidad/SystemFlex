(function () {
    'use strict';
    angular
    .module('app.resorts.recordstay')
    .service('deleteRecordStayModal', deleteRecordStayModal)

    function deleteRecordStayModal($uibModal) {
        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/resorts/recordstay/confirm-delete-record/confirm-delete-record.html',
                controller: 'DeleteRecordStayDialogController',
                controllerAs: 'vm',
                size: size,
                resolve: {
                    locals: function () {
                        return options.locals;
                    }
                }
            });
        }
    }

})();
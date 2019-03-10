(function () {
    'use strict';
    angular
    .module('app.security.roles')
    .service('deleteRolesModal', deleteRolesModal)

    function deleteRolesModal($uibModal) {
        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/security/roles/confirm-delete-role/confirm-delete-role.html',
                controller: 'DeleteRolesDialogController',
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
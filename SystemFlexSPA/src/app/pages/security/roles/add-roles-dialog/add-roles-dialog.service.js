(function () {
    'use strict';

    angular
        .module('app.security.roles')
        .service('rolesModal', rolesModal);


    function rolesModal($uibModal) {

        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/security/roles/add-roles-dialog/add-roles-dialog.html',
                controller: 'AddRolesDialogController',
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

(function () {
    'use strict';

    angular.module('app.security.users')
      .service('usersDeleteModal', usersDeleteModal);

    /** @ngInject */
    function usersDeleteModal($uibModal) {
        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/security/users/confirm-delete-user/confirm-delete-user.html',
                controller: 'deletUsersDialogController',
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
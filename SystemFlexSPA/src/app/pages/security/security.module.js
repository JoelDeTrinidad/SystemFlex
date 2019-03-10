(function () {
    'use strict';

    angular
        .module('app.security', [
            'app.security.users',
            'app.security.roles',
            'app.security.login',
            'app.security.roles_users',
            'app.security.marketing'
             

           
        ])
    .config(config);

    /** @ngInject */
    function config($stateProvider) {
        $stateProvider
            .state('security', {
                url: '/Seguridad',
                template: '<ui-view></ui-view>',
                abstract: true,
                title: 'Seguridad',
                sidebarMeta: {
                    icon: 'ion-locked',
                    order: 100,
                },
            });
    }

    /** @ngInject */
    //function config(msApiProvider) {
    //    msApiProvider.register('security.messages', ['app/data/security/messages/messages.json']);
    //}

})();
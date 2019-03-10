(function () {
    'use strict';
    angular.module('app.security.marketing', [])

      .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider.state('security.marketing', {
            url: '/marketing',
            templateUrl: 'app/pages/security/marketing/marketing.html',
            controller: 'MarketingController as vm'
        });


    }

})();
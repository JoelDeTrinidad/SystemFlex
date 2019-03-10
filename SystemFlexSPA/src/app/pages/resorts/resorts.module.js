(function () {
	'use strict';

	  angular
        .module('app.resorts', [
         'app.resorts.lodgment',
         'app.resorts.recordstay',
         'app.resorts.payment_check'

        ])
    .config(config);

    /** @ngInject */
	  function config($stateProvider) {
        $stateProvider
            .state('resorts', {
                url: '/Reservaciones',
                template: '<ui-view></ui-view>',
                abstract: true,
                title: 'Reservaciones',
                sidebarMeta: {
                	icon: 'ion-ios-location',
                    order: 101,
                },
            });
    }


})();
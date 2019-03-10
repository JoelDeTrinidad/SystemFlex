(function () {
    'use strict';
    angular
    .module('BlurAdmin.theme.components')
    .controller('pageTopController', pageTopController)
    function pageTopController($state, session) {
        var vm = this;
        //Data
        vm.users = session.getSession();
        //Mhetds 
        vm.logout = logout;
        /**
     * Logout Function
     */
        function logout() {
            var groups = _.groupBy(vm.users.menus, function (menu) { return menu.identifierGroup });

            var gropusKey = _.keys(groups);

            _.each(gropusKey, function (key) {
                var group = _.find(vm.users.menus, function (menu) {
                    return menu.identifierGroup == key;
                });

                msNavigationService.deleteItem(key, {
                    title: group.nameGroup,
                    icon: group.iconGroup,
                    weight: group.orderGroup
                });

                _.each(groups[key], function (option) {
                    if (option.isVisible) {
                        msNavigationService.deleteItem(key + '.' + option.identifier, {
                            title: option.name,
                            icon: option.icon,
                            state: option.url,
                            weight: option.order
                        });
                    }
                });
            });
            session.removeSession();
            $state.go('security.login', { loguer: vm.users });
           
        }
       
       
    }
})();
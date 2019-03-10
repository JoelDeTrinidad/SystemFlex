(function ()
{
    'use strict';

    angular
      .module('app.constants', [])
      .constant('WEBAPI', {
          //Developper 
          URL: "http://localhost:33432"
      })
      .constant('_', window._);

})();
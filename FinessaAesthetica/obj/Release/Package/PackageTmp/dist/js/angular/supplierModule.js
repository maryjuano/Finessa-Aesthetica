(function () {
    'use strict';

    angular.module('supplierModule', [])
    .controller('supplierCtrl', SupplierController)
    .factory('supplierService', ServiceFactory);


})();
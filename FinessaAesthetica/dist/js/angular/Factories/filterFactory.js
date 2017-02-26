var FilterFactory = function () {

     var Filter = {};

     Filter.filterSelectedRecord = function (arr) {
         var list = []

         angular.forEach(arr, function (item, index) {

             if (item.IsSelected == true) {
                 list.push(item);
             }

         });

         return list;
     }

    return Filter
}
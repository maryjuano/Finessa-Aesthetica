var Helpers = {
    ShowModal: function (model) {
        $.ajax({
            url: '/Template/Modal', type: 'html', data:
                { Id: model.Id, HeaderIcon: model.HeaderIcon, HeaderTitle: model.HeaderTitle, Body: model.Body }
        })
        .then(function (response) {
            $('#modal-container').append(response);
            $('#' + model.Id).modal('show');
        });
    }
}
var Helpers = {
    ShowModal: function (model) {
        $.ajax({
            url: '/Template/Modal', type: 'html', 
            data: model
        })
        .then(function (response) {
            $('#modal-container').append(response);
            $('#' + model.Id).modal('show');
        });
    },
    ShowModalForm: function (model) {
        $.ajax({
            url: '/Template/ModalForm', type: 'html', 
            data: model
        })
        .then(function (response) {
            $('#modal-container').append(response);
            $('#' + model.Id).modal('show');
        });
    }
}
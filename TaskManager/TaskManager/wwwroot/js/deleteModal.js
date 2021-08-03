$(function () {
    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var id = button.data("id");

        $(this).find('.modal-content input').val(id);
    });

    $("#modalDeleteButton").click(function () {
        $("#myForm").submit();

    });

});

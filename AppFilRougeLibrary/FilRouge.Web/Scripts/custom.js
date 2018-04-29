$("#to_clone").hide();
$("#title").hide();

const max = 4;
let iCheck = 0;
const maxTrue = 3;


$("#add").click(function (event) {
    event.preventDefault();
    $("#title").show();
    if (i < max) {
        $("#to_clone").clone().appendTo("#response_form").removeAttr("id").show();
        i++;
    }
});

$('#response_form').on('click', 'button', function (evt) {
    $(this).closest(".form-group").remove();
    i--;
    if (i == 0) {
        $("#title").hide();
    }
    iCheck--;
    checkboxLocker(iCheck, maxTrue);
});

$('#response_form').on('change', ':checkbox', function (event) {

    if ($(this).prop("checked")) {
        $(this).closest(".form-group").find(".form-control").css("border-color", "green");
        iCheck++;
    }
    else {
        $(this).closest(".form-group").find(".form-control").css("border-color", "red");
        iCheck--;
    }
    checkboxLocker(iCheck, maxTrue);
});

function checkboxLocker(iterator, maxSelected) {
    if (iterator == maxTrue) {
        $('input:checkbox').not(':checked').prop('disabled', true);
    }
    else {
        $('input:checkbox').not(':checked').prop('disabled', false);
    }
}



$("#alert").delay(1800).slideUp(300);



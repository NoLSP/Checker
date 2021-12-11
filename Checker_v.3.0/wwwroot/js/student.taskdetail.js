function LoadSolution(inputId) {
    var input = document.getElementById(inputId);
    var formData = new FormData();
    formData.append("studentResultId", $(input).data("id"));
    formData.append("studentFile", input.files[0]);

    $.ajax({
        url: "/Students/LoadSolution",
        type: "POST",
        data: formData,
        processData: null,
        contentType: null,
        success: function (data) {
            alert(data.Message);
        }
    });
}
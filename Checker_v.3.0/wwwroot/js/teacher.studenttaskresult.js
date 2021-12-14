$(document).ready(function () {
    $("#downloadSolutionButton").click(DownloadSolutionButton);
});

function DownloadSolutionButton(inputId) {
    var input = document.getElementById(inputId);
    var formData = new FormData();
    formData.append("studentResultId", $(input).data("id"));
    formData.append("studentFile", input.files[0]);

    var request = new XMLHttpRequest();
    request.open("POST", "/Students/LoadSolution");
    request.onload = function (e) {
        var response = JSON.parse(e.target.response);

        if (response.success) {
            $("#solutionLoadedDateTime").html("........" + response.loadTime + " " + response.loadDate);
            $("#fileNoteText").html("решение загружено");
        } else {
            $("#fileNoteText").html(response.message);
        }
    };
    request.send(formData);
}
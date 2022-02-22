$(document).ready(function () {
    $("#editTeacherResultLabel").on("click", function (e) {
        EditResult();
    });
});

function EditResult(target) {
    var id = StudentTaskResultId;

    var darkLayer = document.createElement('div'); // слой затемнения
    darkLayer.id = 'shadow'; // id чтобы подхватить стиль
    document.body.appendChild(darkLayer); // включаем затемнение

    var formWindow = document.getElementById('popupWin'); // находим наше "окно"
    $.get({
        url: "/Teachers/EditTeacherResult?teacherResultId=" + id,
        success: function (data) {
            $(formWindow).html(data);
        }
    });

    formWindow.style.display = 'block'; // "включаем" его

    darkLayer.onclick = function () {  // при клике на слой затемнения все исчезнет
        darkLayer.parentNode.removeChild(darkLayer); // удаляем затемнение
        formWindow.style.display = 'none'; // делаем окно невидимым
        return false;
    };
}
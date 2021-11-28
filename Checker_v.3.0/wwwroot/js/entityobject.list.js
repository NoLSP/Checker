$(document).ready(function () {
    $("#createButton").on("click", CreateEntity);
});

function CreateEntity() {
    var darkLayer = document.createElement('div'); // слой затемнения
    darkLayer.id = 'shadow'; // id чтобы подхватить стиль
    document.body.appendChild(darkLayer); // включаем затемнение

    var formWindow = document.getElementById('popupWin'); // находим наше "окно"
    $.get({
        url: "/EntityObjects/" + EntityName + "/Create",
        success: function (data) {
            $(formWindow).html(data);
            $(formWindow).children("#createEntity").click(function () {
                SubmitButtonClick(formWindow);
            });
        }
    });

    formWindow.style.display = 'block'; // "включаем" его

    darkLayer.onclick = function () {  // при клике на слой затемнения все исчезнет
        darkLayer.parentNode.removeChild(darkLayer); // удаляем затемнение
        formWindow.style.display = 'none'; // делаем окно невидимым
        return false;
    };
}

function SubmitButtonClick(formWindow) {
    var entityFields = [];

    var form = $(formWindow).children("form");
    form.find("input").each(function (index, element) {
        entityFields.push({ FieldName: $(element).attr("name"), FieldValue: $(element).val() });
    });
    form.find("select").each(function (index, element) {
        entityFields.push({ FieldName: $(element).attr("name"), FieldValue: $(element).val() });
    });

    $.post({
        url: "/EntityObjects/" + EntityName + "/Create",
        data: JSON.stringify(entityFields),
        success: function () {
            window.location.reload();
        }
    });

    var here = "";
}
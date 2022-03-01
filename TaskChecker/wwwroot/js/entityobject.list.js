$(document).ready(function () {
    $("#createButton").on("click", CreateEntity);
    $(".editButton").on("click", function (e) {
        EditEntity(e);
    });
    $(".deleteButton").on("click", function (e) {
        DeleteEntity(e);
    });
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
            $(formWindow).children("div").children("#createEntity").click(function () {
                SubmitButtonClick(formWindow, "/EntityObjects/" + EntityName + "/Create");
            });
            $(".fileButton").click(function () {
                $(this).parent().children("input").trigger("click");
            });
            $(".fileInput").on("change", function () {
                $(this).parent().children("label").html($(this).val());
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

function EditEntity(e) {
    var darkLayer = document.createElement('div'); // слой затемнения
    darkLayer.id = 'shadow'; // id чтобы подхватить стиль
    document.body.appendChild(darkLayer); // включаем затемнение

    var formWindow = document.getElementById('popupWin'); // находим наше "окно"

    var entityId = $(e.currentTarget).data("id");

    $.get({
        url: "/EntityObjects/" + EntityName + "/Edit/" + entityId,
        success: function (data) {
            $(formWindow).html(data);
            $(formWindow).children("div").children("#createEntity").click(function () {
                SubmitButtonClick(formWindow, "/EntityObjects/" + EntityName + "/Edit/" + entityId);
            });
            $(".fileButton").click(function () {
                $(this).parent().children("input").trigger("click");
            });
            $(".fileInput").on("change", function () {
                $(this).parent().children("label").html($(this).val());
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

function DeleteEntity(e) {
    var darkLayer = document.createElement('div'); // слой затемнения
    darkLayer.id = 'shadow'; // id чтобы подхватить стиль
    document.body.appendChild(darkLayer); // включаем затемнение

    var formWindow = document.getElementById('popupWin'); // находим наше "окно"

    var entityId = $(e.currentTarget).data("id");

    $(formWindow).html("<strong>Вы действительно хотите удалить сущность?</strong>" +
        "<br />" +
        "<button id='acceptButton'>Да</button>" + 
        "<button id='cancelButton'>Нет</button>");

    $(formWindow).children("#acceptButton").click(function () {
        SubmitButtonClick(formWindow, "/EntityObjects/" + EntityName + "/Delete/" + entityId);
    });

    $(formWindow).children("#cancelButton").click(function () {
        darkLayer.parentNode.removeChild(darkLayer); // удаляем затемнение
        formWindow.style.display = 'none'; // делаем окно невидимым
        return false;
    });

    formWindow.style.display = 'block'; // "включаем" его

    darkLayer.onclick = function () {  // при клике на слой затемнения все исчезнет
        darkLayer.parentNode.removeChild(darkLayer); // удаляем затемнение
        formWindow.style.display = 'none'; // делаем окно невидимым
        return false;
    };
}

function SubmitButtonClick(formWindow, url) {
    var entityFields = [];

    var formData = new FormData();
    var form = $(formWindow).children("form");
    var files = [];
    form.find("input").each(function (index, element) {
        if ($(element).attr("type") == "file")
            formData.append($(element).attr("name"), element.files[0]);
        else
            entityFields.push({ FieldName: $(element).attr("name"), FieldValue: $(element).val() });
    });
    form.find("select").each(function (index, element) {
        entityFields.push({ FieldName: $(element).attr("name"), FieldValue: $(element).val() });
    });
    
    formData.append("fields", JSON.stringify(entityFields));
    formData.append("files", files);

    var request = new XMLHttpRequest();
    request.open("POST", url);
    request.send(formData);
    request.onreadystatechange = function() {//Вызывает функцию при смене состояния.
        if(request.readyState == XMLHttpRequest.DONE) {
            if(request.status == 200){
                window.location.reload();
            }else{
                //тут можно обрабатывать ошибки
            }
        }
    };
}
$(document).ready(function () {
    $("#addStudentToGroup").on("click", function () {
        $.get({
            url: "/Teachers/AddStudentToGroupGenerateLink?studentGroupId=" + StudentGroupId,
            success: function (data) {
                if (!data.success)
                    alert(data.reason);
                else {
                    navigator.clipboard.writeText(data.link);
                    alert("Ссылка скопирована в буффер обмена");
                }
            }
        });
    });

    $("#addCourseToStudentsGroup").on("click", function (e) {
        AddCourse(e.target);
    });
});

function AddCourse(target) {
    var darkLayer = document.createElement('div'); // слой затемнения
    darkLayer.id = 'shadow'; // id чтобы подхватить стиль
    document.body.appendChild(darkLayer); // включаем затемнение

    var studentsGroupId = $(target).data("id");

    var modalWin = document.getElementById('popupWin'); // находим наше "окно"
    $.get("/Teachers/AddCourseToStudentsGroup?studentsGroupId=" + studentsGroupId, { layout: null }, function (data) {
        $("#popupWin").html(data);
    });

    modalWin.style.display = 'block'; // "включаем" его

    darkLayer.onclick = function () {  // при клике на слой затемнения все исчезнет
        darkLayer.parentNode.removeChild(darkLayer); // удаляем затемнение
        modalWin.style.display = 'none'; // делаем окно невидимым
        return false;
    };
}

var $tabs = function (target) {
    var
        _elemTabs = (typeof target === 'string' ? document.querySelector(target) : target),
        _eventTabsShow,
        _showTab = function (tabsLinkTarget) {
            var tabsPaneTarget, tabsLinkActive, tabsPaneShow;
            tabsPaneTarget = document.querySelector(tabsLinkTarget.getAttribute('href'));
            tabsLinkActive = tabsLinkTarget.parentElement.querySelector('.tabs__link_active');
            tabsPaneShow = tabsPaneTarget.parentElement.querySelector('.tabs__pane_show');
            // если следующая вкладка равна активной, то завершаем работу
            if (tabsLinkTarget === tabsLinkActive) {
                return;
            }
            // удаляем классы у текущих активных элементов
            if (tabsLinkActive !== null) {
                tabsLinkActive.classList.remove('tabs__link_active');
            }
            if (tabsPaneShow !== null) {
                tabsPaneShow.classList.remove('tabs__pane_show');
            }
            // добавляем классы к элементам (в завимости от выбранной вкладки)
            tabsLinkTarget.classList.add('tabs__link_active');
            tabsPaneTarget.classList.add('tabs__pane_show');
            document.dispatchEvent(_eventTabsShow);
        },
        _switchTabTo = function (tabsLinkIndex) {
            var tabsLinks = _elemTabs.querySelectorAll('.tabs__link');
            if (tabsLinks.length > 0) {
                if (tabsLinkIndex > tabsLinks.length) {
                    tabsLinkIndex = tabsLinks.length;
                } else if (tabsLinkIndex < 1) {
                    tabsLinkIndex = 1;
                }
                _showTab(tabsLinks[tabsLinkIndex - 1]);
            }
        };

    _eventTabsShow = new CustomEvent('tab.show', { detail: _elemTabs });

    _elemTabs.addEventListener('click', function (e) {
        var tabsLinkTarget = e.target;
        // завершаем выполнение функции, если кликнули не по ссылке
        if (!tabsLinkTarget.classList.contains('tabs__link')) {
            return;
        }
        // отменяем стандартное действие
        e.preventDefault();
        _showTab(tabsLinkTarget);
    });

    return {
        showTab: function (target) {
            _showTab(target);
        },
        switchTabTo: function (index) {
            _switchTabTo(index);
        }
    }

};

$tabs('.tabs');
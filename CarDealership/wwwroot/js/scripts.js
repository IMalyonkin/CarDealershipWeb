//файл для работы со страницей для админа


//модуль работы с моделями
var Models = (function () {
    //Приватная переменная хранящая путь до сервера, предоставляющего информацию для модуля
    var url = '/api/models/';
    //Приватная переменная хранящая корневой html элемент, в котором отрисовывается модуль
    var el = "#divModel";

    //инициализация модуля
    var init = function () {
        getData(url);
    };

    //получение данных о модели
    var getData = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                render(data);
            }
        });
    };

    //отрисовка блока с моделями
    var render = function (data) {
        let models = JSON.parse(data);
        let html = "";

        html += '<label>Модель: </label>';
        html += '<div>';
        html += '<select id="selModel">';
        for (var i in models) {
            html += '<option value="' + models[i].id + '">' + models[i].name + '</option>';
        }
        html += '</select>';
        html += '</div>';

        html += '<div class="listEl">';
        html += '<button type="button" class="btn btn-success btn-m" data-toggle="modal" data-target="#createModal" onclick="CreateModal.open(document.getElementById(\'selModel\').value);">Добавить</button>';
        html += '</div>';

        $(el).html(html);
    };

    return {
        init: init
    };
})();

//модуль работы с автомобилями
var Vehicles = (function () {

    var url = '/api/vehicles/';
    var el = "#vehiclesDiv";

    //инициализация модуля
    var init = function () {
        getData(url);
    };

    //получене данных об автомобиле
    var getData = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                render(data);
            }
        });
    };

    //отрисовка блока с автомобилями
    var render = function (data) {
        let vehicles = "";
        let html = "";
        vehicles = JSON.parse(data);
        if (vehicles) {
            for (var i in vehicles) {
                if (i == 0)
                    html += '<div class="row">';
                html += '<div class="col-lg-4 col-md-3 katalog panel panel - warning">';
                html += '<div class="panel-body">';
                html += '<h3>' + vehicles[i].model + '</h3>';
                html += '<p>Комплектация: ' + vehicles[i].kit + '</p>';
                html += '<p>Двигатель: ' + vehicles[i].engineName + ', ' + vehicles[i].engineType + '</p>';
                html += '<p>Мощность: ' + vehicles[i].enginePower + ' л.с.</p>';
                html += '<p>Цвет: ' + vehicles[i].color + '</p>';
                html += '<p>Стоимость: ' + vehicles[i].totalPrice + ' руб.</p>';
                html += '<div class="dropdown">';
                html += '<button type="button" class="btn btn-basic dropdown-toggle btn-block innerBtn" data-toggle="dropdown"> Опции </button>';
                html += '<div class="dropdown-menu">'
                for (var j in vehicles[i].options) {
                    html += '<a class="dropdown-item" href="#">' + vehicles[i].options[j].name + '</a>';
                }
                html += '</div>';

                html += '</div>';
                html += '<button type="button" class="btn btn-primary btn-block innerBtn" data-toggle="modal" data-target="#editModal" onclick="EditModal.open(' + vehicles[i].vehicle.id + ',' + vehicles[i].modelId + ');"> Редактировать </button>';
                html += '<button type="button" class="btn btn-secondary btn-block innerBtn" onclick="Vehicle.remove(' + vehicles[i].vehicle.id + ');"> Удалить </button>';
                html += '</div>';
                html += "</div>";
            }
        }
        html += "</div>";
        $(el).html(html);
    };

    return {
        init: init
    };
})();

//модуль окна редактирования
var EditModal = (function () {

    var vehId = ""; //id автомобиля
    var modId = ""; //id модели
    let vehicle = ""; //выбранный автомобиль

    //очистка ошибок из-за отсутствия доступа
    function clear() {
        $("#editActionMsg").html("");
    }

    //инициализация окна
    var open = function (vId, mId) {
        vehId = vId;
        modId = mId;

        clear();
        getVehicle();
        getEngine();
        getStatus();
        getKit();
        getColor();
    };

    //далее идут функции получения автомобиля, а также
    //двигателей, статусов, комплектаций, и цветов
    //доступных для данного автомобиля
    var getVehicle = function () {
        $.ajax({
            url: '/api/vehicles/' + vehId,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderVehicle(data);
            },
            async: false
        });
    };

    var getEngine = function () {
        $.ajax({
            url: '/api/models/' + modId + '/engines',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderEngine(data);
            },
            async: false
        });
    };

    var getStatus = function () {
        $.ajax({
            url: '/api/vehicles/statuses/',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderStatus(data);
            },
            async: false
        });
    };

    var getKit = function () {
        $.ajax({
            url: '/api/models/' + modId + '/kits',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderKit(data);
            },
            async: false
        });
    };

    var getColor = function () {
        $.ajax({
            url: '/api/models/' + modId + '/colors',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderColor(data);
            },
            async: false
        });
    };

    //далее идут функции отображения автомобиля, а также
    //двигателей, статусов, комплектаций, и цветов
    //доступных для данного автомобиля
    var renderVehicle = function (data) {
        vehicle = JSON.parse(data);
        let html = "";

        html += '<div class="form-group">';
        html += '<label>Двигатель: </label>';
        html += '<div>';
        html += '<select id="selEng">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Статус: </label>';
        html += '<div>';
        html += '<select id="selSt">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Комплектация: </label>';
        html += '<div>';
        html += '<select id="selKit">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Цвет: </label>';
        html += '<div>';
        html += '<select id="selCol">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        $("#editForm").html(html);

        html = '';

        html += '<button type="button" class="btn btn-primary" onclick="Vehicle.update(' + vehicle.id + ');">Сохранить</button>';

        $("#divEditFoot").html(html);
    };

    var renderEngine = function (data) {
        let engines = JSON.parse(data);
        let htmlE = "";
        for (var i in engines) {
            if (vehicle.engineFK == engines[i].id)
                htmlE += '<option selected value="' + engines[i].id + '">' + engines[i].name + '</option>';
            else
                htmlE += '<option value="' + engines[i].id + '">' + engines[i].name + '</option>';
        }
        $("#selEng").html(htmlE);
    };

    var renderStatus = function (data) {
        let statuses = JSON.parse(data);
        let htmlS = "";
        for (var i in statuses) {
            if (vehicle.statusFK == statuses[i].id)
                htmlS += '<option selected value="' + statuses[i].id + '">' + statuses[i].name + '</option>';
            else
                htmlS += '<option value="' + statuses[i].id + '">' + statuses[i].name + '</option>';
        }
        $("#selSt").html(htmlS);
    };

    var renderKit = function (data) {
        let kits = JSON.parse(data);
        let htmlK = "";
        for (var i in kits) {
            if (vehicle.kitFK == kits[i].id)
                htmlK += '<option selected value="' + kits[i].id + '">' + kits[i].name + '</option>';
            else
                htmlK += '<option value="' + kits[i].id + '">' + kits[i].name + '</option>';
        }
        $("#selKit").html(htmlK);
    };

    var renderColor = function (data) {
        let colors = JSON.parse(data);
        let htmlC = "";
        for (var i in colors) {
            if (vehicle.colorFK == colors[i].id)
                htmlC += '<option selected value="' + colors[i].id + '">' + colors[i].name + '</option>';
            else
                htmlC += '<option value="' + colors[i].id + '">' + colors[i].name + '</option>';
        }
        $("#selCol").html(htmlC);
    };

    return {
        open: open,
        clear: clear
    };
})();

//модуль окна создания
//аналогичен окну редактирования
var CreateModal = (function () {

    var modId = "";

    function clear() {
        $("#createActionMsg").html("");
    }

    var open = function (mId) {
        modId = mId;

        clear();
        renderVehicle();
        getEngine();
        getStatus();
        getKit();
        getColor();
    };

    var getEngine = function () {
        $.ajax({
            url: '/api/models/' + modId + '/engines',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderEngine(data);
            },
            async: false
        });
    };

    var getStatus = function () {
        $.ajax({
            url: '/api/vehicles/statuses/',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderStatus(data);
            },
            async: false
        });
    };

    var getKit = function () {
        $.ajax({
            url: '/api/models/' + modId + '/kits',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderKit(data);
            },
            async: false
        });
    };

    var getColor = function () {
        $.ajax({
            url: '/api/models/' + modId + '/colors',
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                renderColor(data);
            },
            async: false
        });
    };

    var renderVehicle = function () {
        let html = "";

        html += '<div class="form-group">';
        html += '<label>Двигатель: </label>';
        html += '<div>';
        html += '<select id="crEng">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Статус: </label>';
        html += '<div>';
        html += '<select id="crSt">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Комплектация: </label>';
        html += '<div>';
        html += '<select id="crKit">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        html += '<div class="form-group">';
        html += '<label>Цвет: </label>';
        html += '<div>';
        html += '<select id="crCol">'
        html += '</select>'
        html += '</div>';
        html += '</div>';

        $("#createForm").html(html);

        html = '';

        html += '<button type="button" class="btn btn-primary" onclick="Vehicle.create();">Добавить</button>';

        $("#divCreateFoot").html(html);
    };

    var renderEngine = function (data) {
        let engines = JSON.parse(data);
        let htmlE = "";
        for (var i in engines) {
            htmlE += '<option value="' + engines[i].id + '">' + engines[i].name + '</option>';
        }
        $("#crEng").html(htmlE);
    };

    var renderStatus = function (data) {
        let statuses = JSON.parse(data);
        let htmlS = "";
        for (var i in statuses) {
            htmlS += '<option value="' + statuses[i].id + '">' + statuses[i].name + '</option>';
        }
        $("#crSt").html(htmlS);
    };

    var renderKit = function (data) {
        let kits = JSON.parse(data);
        let htmlK = "";
        for (var i in kits) {
            htmlK += '<option value="' + kits[i].id + '">' + kits[i].name + '</option>';
        }
        $("#crKit").html(htmlK);
    };

    var renderColor = function (data) {
        let colors = JSON.parse(data);
        let htmlC = "";
        for (var i in colors) {
            htmlC += '<option value="' + colors[i].id + '">' + colors[i].name + '</option>';
        }
        $("#crCol").html(htmlC);
    };

    return {
        open: open,
        clear: clear
    };
})();

//модуль работы с автомобилем: 
//добавление, обновление, удаление
var Vehicle = (function () {

    var url = '/api/vehicles/';

    //добавление
    var create = function () {
        createReq();
    };

    //обновление
    var update = function (id) {
        updateReq(id);
    };

    //удаление
    var remove = function (id) {
        removeReq(id);
    };

    //запросы для добавления, обновления и удаления автомобиля
    var createReq = function () {
        let engine = $('#crEng').val();
        let status = $('#crSt').val();
        let kit = $('#crKit').val();
        let color = $('#crCol').val();

        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                vin: null,
                engineFK: engine,
                statusFK: status,
                kitFK: kit,
                colorFK: color
            }),
            complete: function (xhr) {
                createReqRender(xhr.status);
            }
        });
    };

    var createReqRender = function (status) {
        var msg = "";
        if (status === 401) {
            msg = "Недостаточно прав для выполнения действия";
        } else if (status === 201) {
            Vehicles.init();
            $("#createModal").modal("hide");
        } else {
            msg = "Неизвестная ошибка";
        }
        $("#createActionMsg").html('<span class="badge badge-danger">' + msg + '</span>');
    }

    var updateReq = function (id) {
        const vehicle = {
            engineFK: $('#selEng').val(),
            statusFK: $('#selSt').val(),
            kitFK: $('#selKit').val(),
            colorFK: $('#selCol').val()
        };
        $.ajax({
            url: url + id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(vehicle),
            complete: function (xhr) {
                updateReqRender(xhr.status);
            }
        });
    };

    //вывод ошибок доступа
    var updateReqRender = function (status) {
        var msg = "";
        if (status === 401) {
            msg = "Недостаточно прав для выполнения действия";
        } else if (status === 204) {
            Vehicles.init();
            $("#editModal").modal("hide");
        } else {
            msg = "Неизвестная ошибка";
        }
        $("#editActionMsg").html('<span class="badge badge-danger">' + msg + '</span>');
    }

    var removeReq = function (id) {
        $.ajax({
            url: url + id,
            type: 'DELETE',
            dataType: 'HTML',
            complete: function (xhr) {
                removeReqRender(xhr.status);
            }
        });
    };

    var removeReqRender = function (status) {
        var msg = "";
        if (status === 401) {
            msg = "Недостаточно прав для выполнения действия";
        } else if (status === 204) {
            Vehicles.init();
        } else {
            msg = "Неизвестная ошибка";
        }
        if (msg != "") {
            alert(msg);
        }
    }

    return {
        create: create,
        update: update,
        remove: remove
    };
})();


//модуль начальной инициализации
var App = (function () {
    //Объект, содержащий публичное API
    return {
        init: function () {
            // Инициализация модуля. В ней мы инициализируем все остальные модули на странице
            Models.init();
            Vehicles.init();
        }
    }
})();

App.init();
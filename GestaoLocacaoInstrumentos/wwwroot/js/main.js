$(document).ready(function () {
    const content = $("#content");

    // template AJAX
    function loadTemplate(url) {
        $.ajax({
            url: url,
            method: "GET",
            success: function (data) {
                content.html(data);
            },
            error: function () {
                content.html("<p>Erro ao carregar o conteúdo.</p>");
            }
        });
    }

    // rotas
    $("#homeLink").click(function () {
        loadTemplate("/templates/home.html");
    });

    $("#clientesLink").click(function () {
        loadTemplate("/templates/clientes.html");
        loadClientes();
    });

    $("#agendamentosLink").click(function () {
        loadTemplate("/templates/agendamentos.html");
        loadAgendamentos();
    });

    $("#estudiosLink").click(function () {
        loadTemplate("/templates/estudios.html");
        loadEstudios();
    });

    // Carega dados via API
    function loadClientes() {
        $.ajax({
            url: "/api/clientes",
            method: "GET",
            success: function (data) {
                let html = "<h2>Lista de Clientes</h2><ul>";
                data.forEach(cliente => {
                    html += `<li>${cliente.nome} - ${cliente.email}</li>`;
                });
                html += "</ul>";
                content.append(html);
            },
            error: function () {
                content.append("<p>Erro ao carregar clientes.</p>");
            }
        });
    }

    function loadAgendamentos() {
        $.ajax({
            url: "/api/agendamentos",
            method: "GET",
            success: function (data) {
                let html = "<h2>Lista de Agendamentos</h2><ul>";
                data.forEach(agendamento => {
                    html += `<li>${agendamento.data} - ${agendamento.estudio.nome}</li>`;
                });
                html += "</ul>";
                content.append(html);
            },
            error: function () {
                content.append("<p>Erro ao carregar agendamentos.</p>");
            }
        });
    }

    function loadEstudios() {
        $.ajax({
            url: "/api/estudios",
            method: "GET",
            success: function (data) {
                let html = "<h2>Lista de Estúdios</h2><ul>";
                data.forEach(estudio => {
                    html += `<li>${estudio.nome} - ${estudio.capacidade}</li>`;
                });
                html += "</ul>";
                content.append(html);
            },
            error: function () {
                content.append("<p>Erro ao carregar estúdios.</p>");
            }
        });
    }

    // Carregar Home ao iniciar
    $("#homeLink").trigger("click");
});

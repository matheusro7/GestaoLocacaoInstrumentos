document.addEventListener("DOMContentLoaded", () => {
    const apiUrl = "/api/Cliente";

    // Referências aos elementos da página
    const clienteList = document.getElementById("clienteList");
    const clienteForm = document.getElementById("clienteForm");
    const nomeInput = document.getElementById("nome");
    const emailInput = document.getElementById("email");
    const senhaInput = document.getElementById("senha");

    // Função para carregar clientes
    async function loadClientes() {
        try {
            const response = await fetch(apiUrl);
            const clientes = await response.json();

            clienteList.innerHTML = "";
            clientes.forEach(cliente => {
                const li = document.createElement("li");
                li.textContent = `${cliente.nome} (${cliente.email})`;
                const deleteBtn = document.createElement("button");
                deleteBtn.textContent = "Excluir";
                deleteBtn.addEventListener("click", () => deleteCliente(cliente.id));
                li.appendChild(deleteBtn);
                clienteList.appendChild(li);
            });
        } catch (error) {
            console.error("Erro ao carregar clientes:", error);
        }
    }

    // Função para adicionar cliente
    async function addCliente(event) {
        event.preventDefault();
        try {
            const cliente = {
                nome: nomeInput.value,
                email: emailInput.value,
                senha: senhaInput.value,
            };

            const response = await fetch(apiUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(cliente),
            });

            if (response.ok) {
                nomeInput.value = "";
                emailInput.value = "";
                senhaInput.value = "";
                loadClientes();
            } else {
                console.error("Erro ao adicionar cliente:", response.statusText);
            }
        } catch (error) {
            console.error("Erro ao adicionar cliente:", error);
        }
    }

    // Função para excluir cliente
    async function deleteCliente(id) {
        try {
            const response = await fetch(`${apiUrl}/${id}`, {
                method: "DELETE",
            });

            if (response.ok) {
                loadClientes();
            } else {
                console.error("Erro ao excluir cliente:", response.statusText);
            }
        } catch (error) {
            console.error("Erro ao excluir cliente:", error);
        }
    }

    // Event listeners
    clienteForm.addEventListener("submit", addCliente);

    // Inicializar lista
    loadClientes();
});

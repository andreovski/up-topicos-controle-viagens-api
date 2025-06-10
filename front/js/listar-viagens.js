import { apagarViagem } from './apagar-viagem.js';

let viagemEditandoId = null;

export function preencherFormularioEdicao(viagem) {
  document.getElementById('destino').value = viagem.destino;
  document.getElementById('DataPartida').value = viagem.dataPartida ? viagem.dataPartida.split('T')[0] : '';
  document.getElementById('DataRetorno').value = viagem.dataRetorno ? viagem.dataRetorno.split('T')[0] : '';
  document.getElementById('NomeViajante').value = viagem.nomeViajante;
  document.getElementById('Preco').value = viagem.preco;
  document.getElementById('viagemEditandoId').value = viagem.id || '';

  document.querySelector('.form-viagem button[type="submit"]').textContent = 'Salvar edição';
}

async function renderViagens() {
  const baseUrl = 'http://localhost:5199/api/viagens'

  const response = await fetch(baseUrl);
  const viagens = await response.json();
  const tbody = document.getElementById("viagens-tbody");
  tbody.innerHTML = "";

  function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString('pt-BR', {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit'
    });
  }

  viagens.forEach((viagem) => {
    const tr = document.createElement("tr");

    tr.innerHTML = `
      <td>${viagem.id}</td>
      <td>${viagem.destino}</td>
      <td>${formatDate(viagem.dataPartida)}</td>
      <td>${formatDate(viagem.dataRetorno)}</td>
      <td>${viagem.nomeViajante}</td>
      <td>${formatDate(viagem.dataAtualizacao)}</td>
      <td>
        <button class="editar-btn primary">Editar</button>
        <button class="apagar-btn">Apagar</button>
      </td>
    `;
    
    tr.querySelector('.apagar-btn').addEventListener('click', () => apagarViagem(viagem.id));
    tr.querySelector('.editar-btn').addEventListener('click', () => preencherFormularioEdicao(viagem));

    tbody.appendChild(tr);
  });
}

// Chame a função ao carregar a página
window.addEventListener("DOMContentLoaded", renderViagens);
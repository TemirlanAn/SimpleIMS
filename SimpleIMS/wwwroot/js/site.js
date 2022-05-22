window.addEventListener('DOMContentLoaded', () => {
  const deleteModal = document.getElementById('deleteModal')
  deleteModal.addEventListener('show.bs.modal', event => {
    const button = event.relatedTarget
    const id = button.getAttribute('data-bs-id')
    const input = document.getElementById('id');
    input.value = id;
  })
});
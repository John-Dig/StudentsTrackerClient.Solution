﻿const pause = async (ms) => new Promise(resolve => setTimeout(resolve, ms));

const showModal = async modalId => {
  document.body.classList.add('veiled');
  [...document.querySelectorAll(`.modal`)].forEach(async modalElement => {
    modalElement.classList[modalElement.id !== modalId ? 'add' : 'remove']('hidden');
  });
  await pause(2);
  [...document.querySelectorAll(`.modal`)].forEach(async modalElement => {
    modalElement.classList[modalElement.id !== modalId ? 'add' : 'remove']('obscured');
  });
}
const hideModal = async modalId => {
  console.log('hiding', modalId)
  document.body.classList.remove('veiled');
  document.getElementById(`${modalId}`).classList.add('obscured');
  await pause(300);
  document.getElementById(`${modalId}`).classList.add('hidden');
}
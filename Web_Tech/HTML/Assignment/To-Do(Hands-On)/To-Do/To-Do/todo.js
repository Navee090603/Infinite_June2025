function addTask() {
    const input = document.getElementById('todo-input');
    const task = input.value.trim();
    if (task === "") return;
    const list = document.getElementById('todo-list');

    const li = document.createElement('li');
    li.textContent = task;

    const delBtn = document.createElement('button');
    delBtn.textContent = "Delete";
    delBtn.className = "delete-btn";
    delBtn.onclick = function () {
        list.removeChild(li);
    };

    li.appendChild(delBtn);
    list.appendChild(li);
    input.value = "";
    input.focus();
}
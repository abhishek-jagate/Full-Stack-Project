const uri = 'api/materials';
let materials = [];

// This function runs when the page is first loaded
document.addEventListener('DOMContentLoaded', function() {
    getMaterials();
});

// Fetches all materials from the API
function getMaterials() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayMaterials(data))
    .catch(error => console.error('Unable to get materials.', error));
}

// Deletes a material after showing a confirmation dialog
function deleteMaterial(id) {
    // This uses the Kendo UI library to create a confirmation popup
    $("<div></div>").kendoDialog({
        width: "400px",
        title: "Delete Confirmation",
        closable: false,
        modal: true,
        content: "<p>Are you sure you want to delete this material?<p>",
        actions: [
            { text: "Cancel" },
            { 
              text: "Yes, Delete", 
              primary: true, 
              action: function() { // This part runs only if you click "Yes"
                fetch(`${uri}/${id}`, {
                    method: 'DELETE'
                })
                .then(() => getMaterials()) // Refresh the list after deleting
                .catch(error => console.error('Unable to delete material.', error));
                return true;
              }
            }
        ]
    });
}

// Displays the list of materials in the HTML table
function _displayMaterials(data) {
  const tBody = document.getElementById('materials');
  tBody.innerHTML = '';

  data.forEach(material => {
    // Create the "Edit" link
    let editLink = document.createElement('a');
    editLink.innerText = 'Edit';
    editLink.href = `index.html?id=${material.id}`;

    // Create the "Delete" button
    let deleteButton = document.createElement('button');
    deleteButton.innerText = 'Delete';
    deleteButton.setAttribute('onclick', `deleteMaterial(${material.id})`);

    // Create the table row and cells
    let tr = tBody.insertRow();
    
    let td1 = tr.insertCell(0);
    td1.appendChild(document.createTextNode(material.name));

    let td2 = tr.insertCell(1);
    td2.appendChild(document.createTextNode(material.category || 'N/A'));

    let td3 = tr.insertCell(2);
    td3.appendChild(editLink);

    let td4 = tr.insertCell(3);
    td4.appendChild(deleteButton);
  });

  materials = data;
}
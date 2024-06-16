const tblBlog = "blogs";
let blogId = null;

// testConfirmMessage();
getBlogTable();


// readBlog();
// createBlog();
// updateBlog();
// deleteBlog("0de0ace5-1afd-43ab-b621-941d0f2a191e");

function readBlog() {
    let lst = getBLogs();
    console.log(lst);
}

function editBlog(id) {
    let lst = getBLogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    let item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
    // return items[0];
}

function createBlog(title, author, content) {
    let lst = getBLogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    Notiflix.Loading.standard();
    setTimeout(() => {
        Notiflix.Loading.remove();
        successMessage("Saving Successful.");
        Notiflix.Notify.success('Complete');
    }, 1500);
    clearControls();
}

function updateBlog(id, title, author, content) {
    let lst = getBLogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    Notiflix.Loading.standard();
    setTimeout(() => {
        Notiflix.Loading.remove();
        successMessage("Updating Successful.");
        Notiflix.Notify.success('Complete changing!');
    }, 1500);
    clearControls();
    getBlogTable();
}

function deleteBlog(id) {
    Notiflix.Confirm.show(
        'Confirm Box',
        'Are you sure to delete this data?',
        'Yes',
        'No',
        function okCb() {
            Notiflix.Loading.standard();

            let lst = getBLogs();

            const items = lst.filter(x => x.id === id);
            if (items.length == 0) {
                console.log("No data found.");
                return;
            }
            lst = lst.filter(x => x.id !== id);
            const jsonBlog = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonBlog);

            Notiflix.Loading.standard();
            setTimeout(() => {
                Notiflix.Loading.remove();
                successMessage("Deleting Successful.");
                Notiflix.Notify.success('Complete!');
            }, 1500);
            getBlogTable();
        },
        function cancelCb() {
            return;
        },
        {
        },
    );
}

function getBLogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}
$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId == null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogTable();
})

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBLogs();
    let count = 0;
    let htmlBows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" data-id="${item.id}" onclick="editBlog('${item.id}')" >Edit</button>
                <button type="button" class="btn btn-danger" data-blog-id="${item.id}" onclick="deleteBlog('${item.id}')" >Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>`;
        htmlBows += htmlRow;
    });

    $('#tbody').html(htmlBows);
}

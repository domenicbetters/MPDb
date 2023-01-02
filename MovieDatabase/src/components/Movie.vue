<template>
    <td>{{movie.name}}</td>
    <td>{{movie.description}}</td>
    <td>{{movie.releaseYear}}</td>
    <td>
        <i @click="onClick" class="action-icon fa-solid fa-square-pen"></i>
        <i @click="onCopyClick" class="action-icon fa-regular fa-copy"></i>
        <i @click="onDelete(movie.id)" class="action-icon fa-solid fa-trash-can"></i>
    </td>

    <div v-if="isEditModalVisable" class="modal-backdrop">
        <div class="modal">
            <header class="modal-header">
                <h1>Edit {{movie.name}}</h1>
            </header>
            <form @submit="onSubmit" class="add-form">
                <section class="modal-body">
                    <div class="form-control">
                        <input id="editName" type="text" v-model="name" name="name" />
                    </div>
                    <div class="form-control">
                        <input id="editDescription" type="text" v-model="description" name="description" placeholder="Description" />
                    </div>
                    <div class="form-control">
                        <input type="text"
                               id="editYear"
                               v-model="releaseYear"
                               name="releaseYear"
                               placeholder="Release Year"
                               style="width:fit-content" />
                    </div>
                </section>

                <footer class="modal-footer">
                    <button type="button"
                            class="btn-bottom edit-button"
                            @click="onClick">
                        Cancel
                    </button>
                    <button type="submit"
                            class="btn-bottom edit-button">
                        Save
                    </button>
                    <button type="button"
                            class="btn-bottom edit-button"
                            @click="onDelete(movie.id)">
                        Delete
                    </button>
                </footer>
            </form>
        </div>
    </div>

    <div v-if="isCopyModalVisable" class="modal-backdrop">
        <div class="modal" style="background-color: #bdbba2">
            <header class="modal-header">
                <h1>Copy {{movie.name}}</h1>
            </header>
            <form @submit="onCopySubmit" class="add-form">
                <section class="modal-body">
                    <slot name="body">

                        <div class="form-control">
                            <input  style="display:none" type="text" v-model="id" name="id" />
                        </div>
                        <div class="form-control">
                            <input id="copyName" type="text" v-model="name" name="name" />
                        </div>
                        <div class="form-control">
                            <input id="copyDescription" type="text" v-model="description" name="description" placeholder="Description" />
                        </div>
                        <div class="form-control">
                            <input type="text"
                                   id="copyYear"
                                   v-model="releaseYear"
                                   name="releaseYear"
                                   placeholder="Release Year"
                                   style="width:fit-content" />
                        </div>


                    </slot>
                </section>

                <footer class="modal-footer">
                    <button type="button"
                            class="btn-bottom copy-button"
                            @click="onCopyClick">
                        Cancel
                    </button>
                    <button type="submit"
                            class="btn-bottom copy-button">
                        Save
                    </button>
                </footer>
            </form>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Movie',
        props: {
            movie: Object
        },
        data() {
            return {
                isEditModalVisable: false,
                isCopyModalVisable: false,
                id: this.movie.id,
                name: this.movie.name,
                description: this.movie.description,
                releaseYear: this.movie.releaseYear,
            }
        },
        methods: {
            onDelete(id) {
                this.$emit('delete-movie', id)
            },
            onClick() {
                this.isEditModalVisable = !this.isEditModalVisable
                this.name = this.movie.name
                this.description = this.movie.description
                this.releaseYear = this.movie.releaseYear
                document.getElementById("editName").style.border = "none";
                document.getElementById("editDescription").style.border = "none";
                document.getElementById("editYear").style.border = "none";
            },
            onCopyClick() {
                this.isCopyModalVisable = !this.isCopyModalVisable
                this.name = this.movie.name
                this.description = this.movie.description
                this.releaseYear = this.movie.releaseYear
                document.getElementById("copyName").style.border = "none";
                document.getElementById("copyDescription").style.border = "none";
                document.getElementById("copyYear").style.border = "none";
            },
            onSubmit(e) {
                e.preventDefault()
                if (this.name.length > 0 || this.name.length <= 50) {
                    document.getElementById("editName").style.border = "none";
                }
                if (this.description.length <= 500) {
                    document.getElementById("editDescription").style.border = "none";
                }
                if (this.releaseYear.length > 0 || isNaN(this.releaseYear) === false) {
                    document.getElementById("editYear").style.border = "none";
                }
                if (this.name.length < 1 || this.name.length > 50) {
                    if (this.name.length < 1) {
                        alert('You must enter a title for this movie.')
                    }
                    else {
                        alert('Title can only be 50 characters or less.')
                    }
                    document.getElementById("editName").style.border = "2px solid red";
                    return
                }
                else if (this.description.length > 500) {
                    alert('Description can not exceed 500 characters')
                    document.getElementById("editDescription").style.border = "2px solid red";
                    return
                }
                else if (this.releaseYear.length < 1 || isNaN(this.releaseYear)) {
                    if (this.releaseYear.length < 1) {
                        alert('Movie must have a release year.')
                    }
                    else {
                        alert('Release year entered must be an actual numerical year.')
                    }
                    document.getElementById("editYear").style.border = "2px solid red";
                    return
                }
                else {

                    const newMovie = {

                        id: this.id,
                        name: this.name,
                        description: this.description,
                        releaseYear: this.releaseYear,
                    }

                    this.$emit('edit-movie', newMovie)

                    this.name = ''
                    this.description = ''
                    this.releaseYear = ''

                    document.getElementById("editName").style.border = "none";
                    document.getElementById("editDescription").style.border = "none";
                    document.getElementById("editYear").style.border = "none";

                    alert('Congrats! you just edited a movie!.')

                    this.isEditModalVisable = !this.isEditModalVisable

                    
                }

            },
            onCopySubmit(e) {
                e.preventDefault()
                if (this.name.length > 0 || this.name.length <= 50) {
                    document.getElementById("copyName").style.border = "none";
                }
                if (this.description.length <= 500) {
                    document.getElementById("copyDescription").style.border = "none";
                }
                if (this.releaseYear.length > 0 || isNaN(this.releaseYear) === false) {
                    document.getElementById("copyYear").style.border = "none";
                }
                if (this.name.length < 1 || this.name.length > 50) {
                    if (this.name.length < 1) {
                        alert('You must enter a title for this movie.')
                    }
                    else {
                        alert('Title can only be 50 characters or less.')
                    }
                    document.getElementById("copyName").style.border = "2px solid red";
                    return
                }
                else if (this.description.length > 500) {
                    alert('Description can not exceed 500 characters')
                    document.getElementById("copyDescription").style.border = "2px solid red";
                    return
                }
                else if (this.releaseYear.length < 1 || isNaN(this.releaseYear)) {
                    if (this.releaseYear.length < 1) {
                        alert('Movie must have a release year.')
                    }
                    else {
                        alert('Release year entered must be an actual numerical year.')
                    }
                    document.getElementById("copyYear").style.border = "2px solid red";
                    return
                }
                else {

                    const newMovie = {

                        name: this.name,
                        description: this.description,
                        releaseYear: this.releaseYear,
                    }

                    this.$emit('copy-movie', newMovie)



                    this.name = ''
                    this.description = ''
                    this.releaseYear = ''

                    document.getElementById("copyName").style.border = "none";
                    document.getElementById("copyDescription").style.border = "none";
                    document.getElementById("copyYear").style.border = "none";

                    alert('Congrats! you just copied a movie!.')

                    this.isCopyModalVisable = !this.isCopyModalVisable
                }
            }
        },
    }
</script>

<style scope>
    .fa-trash-can {
        color: #5c0600;
    }
    .fa-square-pen {
        color: #252329
    }
    .fa-copy {
        color: #292823
    }

    i {
        margin: 0px 5px;
    }

    .modal-backdrop {
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background-color: rgba(0, 0, 0, 0.8);
        display: flex;
        justify-content: center;
        align-items: center;
        animation: fadeIn .5s;
    }

    .modal {
        background: #aba2bd;
        box-shadow: 2px 2px 20px 1px black;
        overflow-x: auto;
        display: flex;
        flex-direction: column;
        border-radius: 5px;
        width: 50%;
        min-width: 400px;
    }

    .modal-header,
    .modal-footer {
        display: flex;
    }

    .modal-header {
        border-bottom: 1px solid #eeeeee;
        color: black;
        justify-content: center;
        padding: 2px;
    }

    .modal-footer {
        border-top: 1px solid #eeeeee;
        flex-direction: row;
        justify-content: space-evenly;
        align-items: center;
        padding: 15px;
    }

    .modal-body {
        display:flex;
        flex-direction:column;
        padding: 20px 10px;
    }


    .btn-bottom {
        color: white;
        background: #252329;
        border-radius: 2px;
    }

    input {
        width: 80%;
        text-align: center;
        margin: 10px;
    }
    .form-control {
        display:flex;
        flex-direction:column;
        justify-content:center;
        align-items:center;
    }
    .action-icon:hover {
        cursor:pointer;
    }
    .action-icon:active {
       color: white;
    }
    .copy-button {
        background: #292823;
    }
    .copy-button:active {
        background: #1a1814;
    }
    .edit-button:active {
        background: #141517;
    }
</style>
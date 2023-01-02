<template>
    <div class="modal-backdrop">
        <div class="modal">
            <header class="modal-header">
                <h1>Edit a Movie</h1>
            </header>
            <form @submit="onSubmit" class="add-form">
                <section class="modal-body">
                    <slot name="body">

                        <div class="form-control">
                            <label>Movie Title</label>
                            <input type="text" v-model="movie.name" v-on:keyup.enter="movie.edit = false" name="movie.name" />
                        </div>
                        <div class="form-control">
                            <label>Description</label>
                            <input type="text" v-model="movie.description" v-on:keyup.enter="movie.edit = false" name="movie.description"  />
                        </div>
                        <div class="form-control">
                            <label>Release Year</label>
                            <input type="text"
                                   v-model="movie.releaseYear" v-on:keyup.enter="movie.edit = false" name="movie.releaseYear" style="width:fit-content" />
                        </div>


                    </slot>
                </section>

                <footer class="modal-footer">
                    <button type="button"
                            class="btn-green"
                            @click="close">
                        Cancel
                    </button>
                    <button type="submit"
                            class="btn-green"
                            @click="close">
                        Save
                    </button>
                </footer>
            </form>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'EditMovie',
        data() {
            return {
                name: '',
                description: '',
                releaseYear: '',

            }
        },
        methods: {
            onSubmit(e) {
                e.preventDefault()
                if (this.name) {
                    alert('try again')
                    return
                }

                const newMovie = {

                    name: this.name,
                    description: this.description,
                    releaseYear: this.releaseYear,
                }

                this.$emit('edit-movie', newMovie)

                this.name = ''
                this.description = ''
                this.releaseYear = ''


            }
        }
    }
</script>

 <style scoped >
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
    }

    .modal {
        background: #8aa195;
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
        position: relative;
        padding: 20px 10px;
    }


    .btn-green {
        color: white;
        background: #232926;
        border-radius: 2px;
    }

    input {
        width: 80%;
        text-align: center;
        margin: 10px;
    }
</style>
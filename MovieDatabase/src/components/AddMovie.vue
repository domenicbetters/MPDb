<template>
    <div class="modal-backdrop">
        <div class="modal">

            <header class="modal-header">
               <h1>Add a Movie</h1>
            </header>

            <form @submit="onSubmit" class="add-form">
                <section class="modal-body">
                        <div class="form-control">
                            <input id="addName" 
                                   type="text" 
                                   v-model="name" 
                                   name="name" 
                                   placeholder="Movie Title" />
                        </div>
                        <div class="form-control">
                            <input id="addDescription" 
                                   type="text" 
                                   v-model="description" 
                                   name="description" 
                                   placeholder="Description" />
                        </div>
                        <div class="form-control">
                            <input id="addYear" type="text"
                                   v-model="releaseYear"
                                   name="releaseYear"
                                   placeholder="Release Year"
                                   style="width:fit-content"/>
                        </div>
                </section>

                <footer class="modal-footer">
                    <button type="button"
                            class="btn-bottom"
                            @click="close">
                        Cancel
                    </button>
                    <button type="submit"
                            class="btn-bottom">
                        Save
                    </button>
                </footer>
            </form>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'AddMovie',

        data() {
            return {
                name: '',
                description: '',
                releaseYear: '',

            }
        },

        methods: {
            close() {
                this.name = ''
                this.description = ''
                this.releaseYear = ''

                document.getElementById("addName").style.border = "none";
                document.getElementById("addDescription").style.border = "none";
                document.getElementById("addYear").style.border = "none";

                this.$emit('close');
            },

            onSubmit(e) {
                e.preventDefault()
                if (this.name.length > 0 || this.name.length <= 50) {
                    document.getElementById("addName").style.border = "none";
                }
                if (this.description.length <= 500) {
                    document.getElementById("addDescription").style.border = "none";
                }
                if (this.releaseYear.length > 0 || isNaN(this.releaseYear) === false ) {
                    document.getElementById("addYear").style.border = "none";
                }
                if (this.name.length < 1 || this.name.length > 50) {
                    if (this.name.length < 1) {
                        alert('You must enter a title for this movie.')
                    }
                    else {
                        alert('Title can only be 50 characters or less.')
                    }
                    document.getElementById("addName").style.border = "2px solid red";
                    return
                }
                else if (this.description.length > 500) {
                    alert('Description can not exceed 500 characters')
                    document.getElementById("addDescription").style.border = "2px solid red";
                    return
                }
                else if (this.releaseYear.length < 1 || isNaN(this.releaseYear)) {
                    if (this.releaseYear.length < 1) {
                        alert('Movie must have a release year.')
                    }
                    else {
                        alert('Release year entered must be an actual numerical year.')
                    }
                    document.getElementById("addYear").style.border = "2px solid red";
                    return
                }
                else {
                    const newMovie = {
                        name: this.name,
                        description: this.description,
                        releaseYear: this.releaseYear,
                    }

                    this.$emit('add-movie', newMovie)

                    this.name = ''
                    this.description = ''
                    this.releaseYear = ''

                    document.getElementById("addName").style.border = "none";
                    document.getElementById("addDescription").style.border = "none";
                    document.getElementById("addYear").style.border = "none";

                    alert('Congrats! you just added a movie!.')

                    this.$emit('close');
                }
            }
        }
    }
</script>

<style scoped>
    
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
        width:50%;
        min-width:400px;
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


    .button-bottom {
        color: white;
        background: #232926;
        border-radius: 2px;
    }

    input {
        width:80%;
        text-align:center;
        margin: 10px;
    }
</style>
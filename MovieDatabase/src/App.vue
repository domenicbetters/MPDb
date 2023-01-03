<template>
    <HeaderComponent />

    <AddMovie class="add-movie-window" @add-movie="addMovie" v-show="isModalVisible"
              @close="closeModal" />

    <div class="button-box">
        <ButtonComponent  @click="showModal" text="Add Movie" />
    </div>

    <MoviesComponent @name-sort="nameSort" @year-sort="yearSort" @delete-movie="deleteMovie" @copy-movie="addMovie" @edit-movie="editMovie" :movies="movies" />

</template>


<script>

    import HeaderComponent from './components/HeaderComponent'
    import MoviesComponent from './components/MoviesComponent'
    import AddMovie from './components/AddMovie'
    import ButtonComponent from './components/ButtonComponent'

    export default {
        name: 'App',

        components: {
            HeaderComponent,
            MoviesComponent,
            AddMovie,
            ButtonComponent,
        },

        data() {
            return {
                movies: [],
                isModalVisible: false,
                isEditModalVisible: false,
                isNameSorted: false,
                isYearSorted: false,
            }
        },

        methods: {
            showModal() {
                this.isModalVisible = true;
            },

            async nameSort() {
                this.movies = await this.fetchMovies()

                if (this.isNameSorted) {
                    this.movies.sort(function (a, b) {
                        let x = a.name.toLowerCase();
                        let y = b.name.toLowerCase();
                        if (x > y) { return -1; }
                        if (x < y) { return 1; }
                        return 0;
                    })

                    document.getElementById("nameUp").style.display = "none";
                    document.getElementById("nameDown").style.display = "inline";
                    document.getElementById("nameUpDown").style.display = "none";
                    document.getElementById("yearUp").style.display = "none";
                    document.getElementById("yearDown").style.display = "none";
                    document.getElementById("yearUpDown").style.display = "inline";

                    this.isNameSorted = !this.isNameSorted
                }
                else {
                    this.movies.sort(function (a, b) {
                        let x = a.name.toLowerCase();
                        let y = b.name.toLowerCase();
                        if (x < y) { return -1; }
                        if (x > y) { return 1; }
                        return 0;
                    })

                    document.getElementById("nameUp").style.display = "inline";
                    document.getElementById("nameDown").style.display = "none";
                    document.getElementById("nameUpDown").style.display = "none";
                    document.getElementById("yearUp").style.display = "none";
                    document.getElementById("yearDown").style.display = "none";
                    document.getElementById("yearUpDown").style.display = "inline";

                    this.isNameSorted = !this.isNameSorted
                }
            },

            async yearSort() {
                this.movies = await this.fetchMovies()

                if (this.isYearSorted) {
                    this.movies.sort(function (a, b) {
                        let x = a.releaseYear;
                        let y = b.releaseYear;
                        if (x > y) { return -1; }
                        if (x < y) { return 1; }
                        return 0;
                    })

                    document.getElementById("nameUp").style.display = "none";
                    document.getElementById("nameDown").style.display = "none";
                    document.getElementById("nameUpDown").style.display = "inline";
                    document.getElementById("yearUp").style.display = "none";
                    document.getElementById("yearDown").style.display = "inline";
                    document.getElementById("yearUpDown").style.display = "none";

                    this.isYearSorted = !this.isYearSorted
                }
                else {
                    this.movies.sort(function (a, b) {
                        let x = a.releaseYear;
                        let y = b.releaseYear;
                        if (x < y) { return -1; }
                        if (x > y) { return 1; }
                        return 0;
                    })

                    document.getElementById("nameUp").style.display = "none";
                    document.getElementById("nameDown").style.display = "none";
                    document.getElementById("nameUpDown").style.display = "inline";
                    document.getElementById("yearUp").style.display = "inline";
                    document.getElementById("yearDown").style.display = "none";
                    document.getElementById("yearUpDown").style.display = "none";

                    this.isYearSorted = !this.isYearSorted
                }
            },

            closeModal() {
                this.isModalVisible = false;
            },
           
            async deleteMovie(id) {
                if (confirm('Are you sure you want to delete this?')) {
                    await fetch(`https://localhost:5001/api/MotionPictures/${id}`, {
                        method: 'DELETE',
                    })

                    this.movies = await this.movies.filter((movie) => movie.id !== id)

                    alert('The movie is now gone forever!')

                }
            },

            async addMovie(movie) {
                
                const res = await fetch('https://localhost:5001/api/MotionPictures', {
                    method: "POST",
                    headers: {
                        'Accept': 'application/json',
                        'Content-type': 'application/json;charset=utf-8',

                    },
                    body: JSON.stringify(movie),
                })

                const data = await res.json()

                this.movies = await [...this.movies, data]
                
            },

            async fetchMovies() {
                const res = await fetch("https://localhost:5001/api/MotionPictures")
                const data = await res.json()
                return data
            },

            async fetchMovie(id) {
                const res = await fetch(`https://localhost:5001/api/MotionPictures/${id}`)
                const data = await res.json()
                return data
            },

            async editMovie(newMovie) {

                const movieToEdit = await this.fetchMovie(newMovie.id)
                const updateMovie = { ...movieToEdit,  name: newMovie.name, description: newMovie.description, releaseYear: newMovie.releaseYear }

                const res = await fetch(`https://localhost:5001/api/MotionPictures/${newMovie.id}`, {
                    method: 'PUT',
                    headers: {
                        'Accept': 'application/json',
                        'Content-type': 'application/json;charset=utf-8',
                    },
                    body: JSON.stringify(updateMovie)
                })

                const data = await res.json()

                const temp = [...this.movies]
                let movieLocation = 0
                for (let i = 0; i < temp.length; i++) {
                    if (temp[i].id === newMovie.id) {
                        movieLocation = i;
                        break;
                    }
                }
                
                temp[movieLocation] = data
                this.movies = temp
            },

        },
        
        async created() {
            this.movies = await this.fetchMovies()
        },

        emits: ['delete-movie', 'edit-movie', 'copy-movie', 'name-sort', 'year-sort']
    }
</script>

<style>

    #app {
        font-family: 'Barlow Condensed', sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: antiquewhite;
        margin-top: 60px;
        display: flex;
        justify-content: center;
        flex-direction: column;
        background-color: #575463;
        background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='100%25' height='100%25'%3E%3Cdefs%3E%3Cpattern id='p' width='100' height='100' patternUnits='userSpaceOnUse' patternTransform='rotate(90) scale(0.2)'%3E%3Cpath id='a' data-color='fill' fill='%23534F60' stroke='%23534F60' stroke-width='48' d='M49-1h2v102h-2z'%3E%3C/path%3E%3C/pattern%3E%3C/defs%3E%3Crect fill='url(%23p)' width='100%25' height='100%25'%3E%3C/rect%3E%3C/svg%3E");
        background-size: cover;
        background-position: center;
        background-repeat: no-repeat;
    }

    .button-box {
        display: flex;
        justify-content: center;
        flex-direction: column;
        align-items:flex-end;
        width: 100%;
    }

    #yearUp{
        display:none;
    }

    #yearDown {
        display: none;
    }
    #yearUpDown {
        color: grey;
    }

    #nameUp {
        display: none;
    }

    #nameDown {
        display: none;
    }

    #nameUpDown {
        color: grey;
    }

    .add-movie-window {
       animation: fadeIn .5s;
    }

    @keyframes fadeIn {
        0% {
            opacity: 0;
        }

        100% {
            opacity: 1;
        }
    }
   
</style>

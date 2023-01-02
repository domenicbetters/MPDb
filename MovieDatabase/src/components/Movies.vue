<template>
    <table>
        <tr>
            <th class="clickableHeader" @click="$emit('name-sort')">
                <i id="nameUp" class="fa-sharp fa-solid fa-arrow-up"></i>
                <i id="nameDown" class="fa-sharp fa-solid fa-arrow-down"></i>
                <i id="nameUpDown" class="fa-solid fa-arrows-up-down"></i>
                Name
            </th>
            <th>Description</th>
            <th class="clickableHeader" @click="$emit('year-sort')">
                <i id="yearUp" class="fa-sharp fa-solid fa-arrow-up"></i>
                <i id="yearDown" class="fa-sharp fa-solid fa-arrow-down"></i>
                <i id="yearUpDown" class="fa-solid fa-arrows-up-down"></i>
                Release Year
            </th>
            <th>Actions</th>
        </tr>
        <tr :key="movie.id" v-for="movie, id) in movies">
            <Movie @delete-movie="$emit('delete-movie', movie.id)"
                   @edit-movie="editMovie"
                   @copy-movie="copyMovie"
                   :movie="movie" />
        </tr>

    </table>

</template>

<script>
    import Movie from './Movie'

    export default {
        name: 'Movies',
        props: {
            movies: Array,
        },
        components: {
            Movie
        },
        methods: {
            copyMovie(movie) {
                this.$emit('copy-movie', movie)
            },
            editMovie(movie) {
                this.$emit('edit-movie', movie)
            },
        },
        data() {
            return {
                name: '',
                description: '',
                releaseYear: '',
            }
        },
        emits: ['delete-movie', 'edit-movie', 'test']
    }
</script>

<style>
    table {
        border: 5px solid #120f1c;
        border-spacing: 50px 0;
        border-collapse: collapse;
    }

    th {
        background-color: #120f1c;
        color: whitesmoke;
        margin: 10px 10px;
        padding: 10px 15px;
        border: 4px outset #1f1a30;
        box-sizing: border-box;
    }

    td {
        border-bottom: 1px solid black;
        padding: 10px 15px;
        color: black;
    }

    table tr:nth-child(odd) td {
        background: #a59fbd;
    }

    table tr:nth-child(even) td {
        background: #635f70;
    }

    .clickableHeader:active {
        background-color: #0A080F;
        border: 4px inset #151120;
    }

    .clickableHeader {
        cursor: pointer;
    }
</style>
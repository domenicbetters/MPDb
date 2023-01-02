<template>
    <button @click="onClick()" ><i class="fa fa-plus-circle"></i>{{text}}</button>
</template>

<script>
    export default {
        name: 'Button',
        props: {
            text: String,
            color: String,
        },
        methods: {
            onClick() {
                this.$emit('toggle-add-movie')
            },
        },
    }
</script>

<style>
    button {
        width: fit-content;
        padding: 4px;
        border-radius: 4px;
        box-shadow: 2px 2px 3px 3px rgb(0, 0, 0, 0.5);
        margin: 10px;
        background: #8aa195;
    }
    button:active {
        background: #2d3631;
        border: 2px inset #2d3631;
    }

    button:hover {
        cursor: pointer;
    }
</style>
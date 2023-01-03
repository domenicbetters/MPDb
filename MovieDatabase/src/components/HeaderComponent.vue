<template>
    <header>
            <h1>{{title}}</h1>
    </header>
</template>

<script>
    
    export default {
        name: 'HeaderComponent',

        props: {
            title: {
                type: String,
                default: 'Motion Picture Database',
            },
        },
    }

</script>

<style scoped>

    header {
        display: flex;
        justify-content: center;
        align-items: center;
        margin-bottom: 20px;
        background: rgb(18,15,28);
        background: linear-gradient(0deg, rgba(18,15,28,1) 0%, rgba(85,71,130,1) 33%, rgba(85,71,130,1) 66%, rgba(18,15,28,1) 100%);
        border: 4px outset #1f1a30;
        box-sizing: border-box;
        box-shadow: 0 2px 2px 2px rgb(0,0,0,0.5);
        font-family: 'Teko', sans-serif;
        font-size: 2rem;
    }

    h1 {
        margin: 0px;
    }

</style>
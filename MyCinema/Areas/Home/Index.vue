

<template>
    <div>

       
        <form action="Auth/Login/Register" method="POST">
            <input type="text" name="userName">
            <input type="text" name="password">
            <input type="text" name="confirmPassword">
            <input type="submit" value="View Report">
        </form>

        <p>Index vue</p>
        <p>_________________________</p>
        <currently-playing-section></currently-playing-section>

        <span>ddd</span>
    </div>
</template>

<script>
    import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'HomeView',
        components: {
            CurrentlyPlayingSection
        }
    }
</script>

<style lang="scss">

</style>

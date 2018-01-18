

<template>
    <div>
        <p>Index vue</p>
        <p>_________________________</p>
        <currently-playing-section></currently-playing-section>

        <span>ddd</span>

        <div class="field">
            <div class="control">
                <input class="input is-primary" type="text" placeholder="Primary input">
            </div>
        </div>
    </div>
</template>

<script>
    import CurrentlyPlayingSection from './Views/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'HomeView',
        components: {
            CurrentlyPlayingSection
        }
    }
</script>

<style lang="scss">
    @import "font-awesome";
</style>

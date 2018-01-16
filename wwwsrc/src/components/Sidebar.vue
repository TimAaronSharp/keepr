<template>
    <div class="sidebar fixed border">
        <div v-if="user.firstName">
            <NewKeep class="il"></NewKeep>
            <NewVault class="il"></NewVault>
            <Vault class="il"></Vault>
            <!-- <ShowKeeps class="il"></ShowKeeps> -->
        </div>

    </div>

</template>

<script>
    import ShowKeeps from './ShowKeeps'
    import Vault from './Vault'
    import NewKeep from './NewKeep'
    import NewVault from './NewVault'
    export default {
        name: 'Sidebar',
        data() {
            return {

            }
        },
        mounted() {

        },

        methods: {

        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        components: {
            ShowKeeps,
            NewKeep,
            NewVault,
            Vault,

        }
    }

</script>

<style scoped>
    .sidebar {
        position: absolute;
        min-height: 100vh;
        width: 25%;
        background: #fa0296;
        /* z-index: -1; */
        margin-left: -1%;
    }
</style>
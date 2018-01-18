<template>
    <div>
        <div class="sidebar fixed">
            <div v-if="user.firstName">
                <button type="button" class="btn btn-primary custom-btn" data-toggle="modal" data-target="#post-new-keep-modal">
                    New Keep
                </button>
                <button type="button" class="btn custom-btn" data-toggle="modal" data-target="#post-new-vault-modal">
                    New Vault
                </button>
                <button @click="showMyVaultsList(); getVaultsByUserId();" class="btn btn-primary custom-btn custom-btn">My Vaults
                </button>
                <button @click="showMyKeepsList(); getKeepsByUserId();" class="btn btn-primary custom-btn">My Keeps</button>

                <button @click="showAllKeepsList" class="btn btn-primary custom-btn">Keeps</button>

                <Vault></Vault>
                <!-- <ShowKeeps class="il"></ShowKeeps> -->
            </div>
            <div v-else>
                <button @click="showAllKeepsList" class="btn btn-primary custom-btn">Keeps</button>
            </div>

        </div>
        <NewKeep class="il"></NewKeep>
        <NewVault class="il"></NewVault>
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

            // this.getVaultsByUserId(),

        },

        methods: {
            showAllKeepsList() {
                if (this.showMyKeeps == true) {
                    this.showMyKeepsList()
                }
                this.$store.dispatch('showAllKeeps')
            },
            showMyKeepsList() {
                if (this.showAllKeeps == true) {
                    this.showAllKeepsList()
                }
                this.$store.dispatch('showMyKeeps')
            },
            getKeepsByUserId() {
                this.$store.dispatch('getKeepsByUserId', this.user.id)
            },
            getVaultsByUserId() {
                this.$store.dispatch('getVaultsByUserId', this.user.id)
            },
            showMyVaultsList() {
                this.$store.dispatch('showMyVaultsList')
            }

        },
        computed: {
            user() {
                return this.$store.state.user
            },
            showMyKeeps() {
                return this.$store.state.showMyKeeps
            },
            showAllKeeps() {
                return this.$store.state.showAllKeeps
            }
        },
        components: {
            // ShowKeeps,
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
        font-size: 1.4rem;
        font-weight: bold;
        background: #fa0296;
        /* z-index: -1; */
        margin-left: -1%;
        margin-top: 4.18%;
        /* overflow: scroll; */
    }

    .fixed {
        position: fixed;
    }

    .keep {
        border-radius: 5px;
        margin-top: 5%;
    }

    .add-to-vault-button {
        background: black;
        color: white;
    }

    .keep-preview {
        font-weight: bold;
    }

    .icons {
        color: black;
        margin-right: 1rem;
    }
</style>
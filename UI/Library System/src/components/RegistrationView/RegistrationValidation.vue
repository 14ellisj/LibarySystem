<script lang="ts">
import '../../styles/variables.css'
import { defineComponent } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'RegistrationValidation',
    setup() {
        const store = useUserStore();
        return {
            store,
        };
    },
    methods: {
        async push() {
            this.$router.push('/home');
        },
        async setLoggedIn() {
            await this.store.setLoggedIn()
        }
    }
});
</script>
import { AppBar, Box, Button, Stack, Toolbar } from "@mui/material"
import { useNavigate } from "react-router-dom"

const Header = () => {
    const navigate = useNavigate()

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{
                backgroundColor: "white",
                boxShadow: "none"
            }}>
                <Toolbar>
                    <Box sx={{ flexGrow: 1 }} component="div" >
                        <img src="/logo.png" />
                    </Box>
                    <Stack direction="row" gap={3}>
                        <Button onClick={() => navigate("/sign-up")} color="primary">Sign Up</Button>
                        <Button onClick={() => navigate("/login")} variant="contained" color="primary">Login</Button>
                    </Stack>
                </Toolbar>
            </AppBar>
        </Box>
    )
}

export default Header
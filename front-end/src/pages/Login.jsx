import { Box, Button, Container, Stack, TextField, Typography } from "@mui/material"
import { Link } from "react-router-dom"

const Login = () => {
    return (
        <Box marginY={5}>
            <Container maxWidth="sm">
                <Stack gap="16px">
                    <Typography sx={{
                        fontSize: "24px",
                    }} color="primary">Welcome Back</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Please login first</Typography>
                </Stack>
                <Stack gap={4} marginY={4}>
                    <TextField type="email" label="Email" variant="outlined" />
                    <TextField type="password" label="Password" variant="outlined" />
                </Stack>
                <Stack direction="row" gap={1}>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Forgot Password?</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="blue"><Link to="/forgot-password">Click here</Link></Typography>
                </Stack>
                <Box component="div" textAlign="end">
                    <Button variant="contained" color="primary">Login</Button>
                </Box>
                <Stack marginTop={4} justifyContent="center" direction="row" gap={1}>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Dont have account?</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="blue"><Link to="/sign-up">Sign Up here</Link></Typography>
                </Stack>
            </Container>
        </Box>
    )
}

export default Login
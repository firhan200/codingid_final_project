import { Box, Button, Container, Stack, TextField, Typography } from "@mui/material"
import { Link } from "react-router-dom"

const SignUp = () => {
    return (
        <Box marginY={5}>
            <Container maxWidth="sm">
                <Stack gap="16px">
                    <Typography sx={{
                        fontSize: "24px",
                    }} color="primary">Lets Join our course!</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Please register first</Typography>
                </Stack>
                <Stack gap={4} marginY={4}>
                    <TextField type="text" label="Name" variant="outlined" />
                    <TextField type="email" label="Email" variant="outlined" />
                    <TextField type="password" label="Password" variant="outlined" />
                    <TextField type="password" label="Confirm Password" variant="outlined" />
                </Stack>
                <Box component="div" textAlign="end">
                    <Button variant="contained" color="primary">Sign Up</Button>
                </Box>
                <Stack marginTop={4} justifyContent="center" direction="row" gap={1}>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Have account?</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="blue"><Link to="/login">Login here</Link></Typography>
                </Stack>
            </Container>
        </Box>
    )
}

export default SignUp
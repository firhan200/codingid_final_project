import { Box, Button, Container, Stack, TextField, Typography } from "@mui/material"

const ForgotPassword = () => {
    return (
        <Box marginY={5}>
            <Container maxWidth="sm">
                <Stack gap="16px">
                    <Typography sx={{
                        fontSize: "24px",
                    }} color="secondary">Reset Password</Typography>
                    <Typography sx={{
                        fontSize: "16px"
                    }} color="secondary">Send OTP code to your email address</Typography>
                </Stack>
                <Stack gap={4} marginY={4}>
                    <TextField type="email" label="Email" variant="outlined" />
                </Stack>
                <Stack component="div" direction="row" justifyContent="end" gap={2}>
                    <Button variant="outlined" color="primary">Cancel</Button>
                    <Button variant="contained" color="primary">Confirm</Button>
                </Stack>
            </Container>
        </Box>
    )
}

export default ForgotPassword
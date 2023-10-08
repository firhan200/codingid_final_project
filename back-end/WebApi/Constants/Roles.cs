namespace WebApi.Constants;

public static class Roles {
    public static string USER = "user";
    public static string ADMIN = "admin";

    public static string GetAdminRoles(){
        return ADMIN;
    }
}
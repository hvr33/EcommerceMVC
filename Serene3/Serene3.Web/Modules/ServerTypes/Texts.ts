import { proxyTexts } from "@serenity-is/corelib";

namespace texts {

    export declare namespace Db {

        namespace Administration {

            namespace Language {
                export const LanguageId: string;
                export const LanguageName: string;
            }

            namespace Role {
                export const RoleId: string;
                export const RoleName: string;
            }

            namespace RolePermission {
                export const PermissionKey: string;
                export const RoleId: string;
                export const RoleName: string;
                export const RolePermissionId: string;
            }

            namespace User {
                export const DisplayName: string;
                export const Email: string;
                export const InsertDate: string;
                export const InsertUserId: string;
                export const IsActive: string;
                export const LastDirectoryUpdate: string;
                export const Password: string;
                export const PasswordConfirm: string;
                export const PasswordHash: string;
                export const PasswordSalt: string;
                export const Roles: string;
                export const Source: string;
                export const UpdateDate: string;
                export const UpdateUserId: string;
                export const UserId: string;
                export const UserImage: string;
                export const Username: string;
            }

            namespace UserPermission {
                export const Granted: string;
                export const PermissionKey: string;
                export const User: string;
                export const UserId: string;
                export const UserPermissionId: string;
                export const Username: string;
            }

            namespace UserRole {
                export const RoleId: string;
                export const RoleName: string;
                export const User: string;
                export const UserId: string;
                export const UserRoleId: string;
                export const Username: string;
            }
        }

        namespace com {

            namespace cart {
                export const Id: string;
                export const Photo: string;
                export const Price: string;
                export const Productid: string;
                export const ProductidName: string;
                export const Quntity: string;
                export const Userid: string;
            }

            namespace cetogery {
                export const Description: string;
                export const Id: string;
                export const Name: string;
                export const Photos: string;
            }

            namespace cities {
                export const Id: string;
                export const Name: string;
                export const StateId: string;
                export const StateName: string;
            }

            namespace countries {
                export const Id: string;
                export const Name: string;
            }

            namespace order {
                export const Address: string;
                export const CityId: string;
                export const CityName: string;
                export const CountryId: string;
                export const CountryName: string;
                export const CustomerName: string;
                export const Email: string;
                export const EntityDate: string;
                export const Id: string;
                export const Name: string;
                export const Onlinepaid: string;
                export const OrderDate: string;
                export const Phone: string;
                export const Productid: string;
                export const StateId: string;
                export const StateName: string;
                export const Userid: string;
            }

            namespace orderdetials {
                export const Entitydata: string;
                export const Id: string;
                export const Orderid: string;
                export const OrderidUserid: string;
                export const Price: string;
                export const Productid: string;
                export const ProductidName: string;
                export const Quantity: string;
                export const Totalprice: string;
            }

            namespace payments {
                export const Amount: string;
                export const CreatedAt: string;
                export const Currency: string;
                export const Id: string;
                export const OrderId: string;
                export const OrderUserid: string;
                export const Provider: string;
                export const ProviderPaymentId: string;
                export const RawResponse: string;
                export const Status: string;
                export const UpdatedAt: string;
            }

            namespace product {
                export const Ceito: string;
                export const CeitoName: string;
                export const Description: string;
                export const Entitydata: string;
                export const Id: string;
                export const Name: string;
                export const Photo: string;
                export const Price: string;
                export const Productquntity: string;
                export const Rating: string;
                export const ReviewCount: string;
                export const Reviewurl: string;
                export const Siplername: string;
                export const Type: string;
            }

            namespace productimage {
                export const Id: string;
                export const Image: string;
                export const Productid: string;
                export const ProductidName: string;
            }

            namespace review {
                export const Description: string;
                export const Email: string;
                export const Id: string;
                export const Name: string;
                export const Subject: string;
            }

            namespace review2 {
                export const CreatedAt: string;
                export const Description: string;
                export const Email: string;
                export const Id: string;
                export const Name: string;
                export const ProductId: string;
                export const ProductName: string;
                export const Rating: string;
                export const Subject: string;
            }

            namespace states {
                export const CountryId: string;
                export const CountryName: string;
                export const Id: string;
                export const Name: string;
            }
        }
    }

    export declare namespace Forms {

        namespace Membership {

            namespace Login {
                export const ForgotPassword: string;
                export const LoginToYourAccount: string;
                export const RememberMe: string;
                export const SignInButton: string;
                export const SignUpButton: string;
            }

            namespace SignUp {
                export const ActivateEmailSubject: string;
                export const ActivationCompleteMessage: string;
                export const ConfirmEmail: string;
                export const ConfirmPassword: string;
                export const DisplayName: string;
                export const Email: string;
                export const FormInfo: string;
                export const FormTitle: string;
                export const Password: string;
                export const SubmitButton: string;
                export const Success: string;
            }
        }
        export const SiteTitle: string;
    }

    export declare namespace Site {

        namespace AccessDenied {
            export const ClickToChangeUser: string;
            export const ClickToLogin: string;
            export const LackPermissions: string;
            export const NotLoggedIn: string;
            export const PageTitle: string;
        }

        namespace Layout {
            export const Language: string;
            export const Theme: string;
        }

        namespace RolePermissionDialog {
            export const DialogTitle: string;
            export const EditButton: string;
            export const SaveSuccess: string;
        }

        namespace UserDialog {
            export const EditPermissionsButton: string;
            export const EditRolesButton: string;
        }

        namespace UserPermissionDialog {
            export const DialogTitle: string;
            export const Grant: string;
            export const Permission: string;
            export const Revoke: string;
            export const SaveSuccess: string;
        }

        namespace ValidationError {
            export const Title: string;
        }
    }

    export declare namespace Validation {
        export const AuthenticationError: string;
        export const CurrentPasswordMismatch: string;
        export const DeleteForeignKeyError: string;
        export const EmailConfirm: string;
        export const EmailInUse: string;
        export const InvalidActivateToken: string;
        export const InvalidResetToken: string;
        export const MinRequiredPasswordLength: string;
        export const PasswordConfirmMismatch: string;
        export const SavePrimaryKeyError: string;
    }

}

const Texts: typeof texts = proxyTexts({}, '', {
    Db: {
        Administration: {
            Language: {},
            Role: {},
            RolePermission: {},
            User: {},
            UserPermission: {},
            UserRole: {}
        },
        com: {
            cart: {},
            cetogery: {},
            cities: {},
            countries: {},
            order: {},
            orderdetials: {},
            payments: {},
            product: {},
            productimage: {},
            review: {},
            review2: {},
            states: {}
        }
    },
    Forms: {
        Membership: {
            Login: {},
            SignUp: {}
        }
    },
    Site: {
        AccessDenied: {},
        Layout: {},
        RolePermissionDialog: {},
        UserDialog: {},
        UserPermissionDialog: {},
        ValidationError: {}
    },
    Validation: {}
}) as any;

export const AccessDeniedViewTexts = Texts.Site.AccessDenied;

export const LoginFormTexts = Texts.Forms.Membership.Login;

export const MembershipValidationTexts = Texts.Validation;

export const RolePermissionDialogTexts = Texts.Site.RolePermissionDialog;

export const SignUpFormTexts = Texts.Forms.Membership.SignUp;

export const SiteFormTexts = Texts.Forms;

export const SiteLayoutTexts = Texts.Site.Layout;

export const SqlExceptionHelperTexts = Texts.Validation;

export const UserDialogTexts = Texts.Site.UserDialog;

export const UserPermissionDialogTexts = Texts.Site.UserPermissionDialog;

export const ValidationErrorViewTexts = Texts.Site.ValidationError;
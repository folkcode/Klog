declare module "CommonAnimations" {
    export function fadeIn(idOrClass: string): void;
    export function fadeOut(idOrClass: string): void;
    export function fadeInOut(name: string, time: number, opacityTo: number)
}
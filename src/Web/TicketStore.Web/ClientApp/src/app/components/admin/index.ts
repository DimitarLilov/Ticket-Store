import { AdminAllEventComponent } from './event/admin-event.component';
import { EventCreateComponent } from './event/event-create/event-create.component';
import { EventEditComponent } from './event/event-edit/event-edit.component';
import { EventDeleteComponent } from './event/event-delete/event-delete.component';
import { AdminAllCategoryComponent } from './category/admin-category.component';
import { CategoryCreateComponent } from './category/category-create/category-create.component';
import { CategoryEditComponent } from './category/category-edit/category-edit.component';
import { CategoryDeleteComponent } from './category/category-delete/category-delete.component';
import { AdminComponent } from './admin.component';
import { TicketCreateComponent } from './ticket/ticket-create/ticket-create.component';


export * from './event/admin-event.component';
export * from './event/event-create/event-create.component';
export * from './event/event-edit/event-edit.component';
export * from './event/event-delete/event-delete.component';
export * from './category/category-create/category-create.component';
export * from './category/category-edit/category-edit.component';
export * from './category/admin-category.component';
export * from './category/category-delete/category-delete.component';
export * from './admin.component';
export * from './ticket/ticket-create/ticket-create.component';


export const ADMIN_COMPONTNTS = [
    EventCreateComponent,
    EventEditComponent,
    EventDeleteComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    AdminAllEventComponent,
    AdminComponent,
    AdminAllCategoryComponent,
    CategoryDeleteComponent,
    TicketCreateComponent
]
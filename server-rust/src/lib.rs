use spacetimedb::{Identity, ReducerContext, Table, table, reducer};

#[table(name = player, public)]
pub struct Player {
    #[primary_key]
    id: Identity,
    online: bool,
}

#[reducer(client_connected)]
pub fn client_connected(ctx: &ReducerContext) -> Result<(), String> {
    log::debug!("{} just connected", ctx.sender);
    if let Some(user) = ctx.db.player().id().find(ctx.sender) {
        ctx.db.player().id().update(Player {
            online: true,
            ..user
        });
    } else {
        ctx.db.player().insert(Player {
            id: ctx.sender,
            online: true,
        });
    }
    Ok(())
}

#[reducer(client_disconnected)]
pub fn client_disconnected(ctx: &ReducerContext) -> Result<(), String> {
    if let Some(user) = ctx.db.player().id().find(ctx.sender) {
		ctx.db.player().id().update(Player {
            online: false,
            ..user
        });
	} else {
		log::warn!(
			"Disconnect event for unknown user with identity {:?}",
			ctx.sender
		);
	}
    Ok(())
}